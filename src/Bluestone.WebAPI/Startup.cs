using Bluestone.CrossCuttingConcerns.Csv;
using Bluestone.CrossCuttingConcerns.Excel;
using Bluestone.Domain.Entities;
using Bluestone.Domain.Identity;
using Bluestone.Infrastructure.Csv;
using Bluestone.Infrastructure.Excel.ClosedXML;
using Bluestone.Infrastructure.Identity;
using Bluestone.Infrastructure.Localization;
using Bluestone.Infrastructure.Monitoring;
using Bluestone.Infrastructure.Web.Filters;
using Bluestone.WebAPI.ConfigurationOptions;
using Bluestone.WebAPI.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace Bluestone.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            AppSettings = new AppSettings();
            Configuration.Bind(AppSettings);
        }

        public IConfiguration Configuration { get; }
        private AppSettings AppSettings { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);

            services.AddMonitoringServices(AppSettings.Monitoring);

            services.AddControllers(configure =>
            {
                configure.Filters.Add(typeof(GlobalExceptionFilter));
            }).AddMonitoringServices(AppSettings.Monitoring);

            services.AddSignalR();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowedOrigins", builder => builder
                    .WithOrigins(AppSettings.CORS.AllowedOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                options.AddPolicy("SignalRHubs", builder => builder
                    .WithOrigins(AppSettings.CORS.AllowedOrigins)
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST")
                    .AllowCredentials());

                options.AddPolicy("AllowAnyOrigin", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

                options.AddPolicy("CustomPolicy", builder => builder
                    .AllowAnyOrigin()
                    .WithMethods("Get")
                    .WithHeaders("Content-Type"));
            });

            services.AddDateTimeProvider();

            services.AddPersistence(AppSettings.ConnectionStrings.BluestoneDb)
                    .AddDomainServices()
                    .AddApplicationServices((Type serviceType, Type implementationType, ServiceLifetime serviceLifetime) =>
                    {
                        services.AddInterceptors(serviceType, implementationType, serviceLifetime, AppSettings.Interceptors);
                    })
                    .ConfigureInterceptors()
                    .AddIdentityCore();

            //services.AddDataProtection()
            //    .SetApplicationName("Bluestone");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = AppSettings.IdentityServerAuthentication.Authority;
                    options.Audience = AppSettings.IdentityServerAuthentication.ApiName;
                    options.RequireHttpsMetadata = AppSettings.IdentityServerAuthentication.RequireHttpsMetadata;
                });

            services.AddAuthorizationPolicies(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    $"Bluestone",
                    new OpenApiInfo()
                    {
                        Title = "Bluestone API",
                        Version = "1",
                        Description = "Bluestone API Specification.",
                        Contact = new OpenApiContact
                        {
                            Email = "abc.xyz@gmail.com",
                            Name = "Phong Nguyen",
                            Url = new Uri("https://github.com/phongnguyend"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT"),
                        },
                    });

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token to access this API",
                });

                setupAction.AddSecurityDefinition("Oidc", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri(AppSettings.IdentityServerAuthentication.Authority + "/connect/token", UriKind.Absolute),
                            AuthorizationUrl = new Uri(AppSettings.IdentityServerAuthentication.Authority + "/connect/authorize", UriKind.Absolute),
                            Scopes = new Dictionary<string, string>
                            {
                                { "openid", "OpenId" },
                                { "profile", "Profile" },
                                { "Bluestone.WebAPI", "Bluestone WebAPI" },
                            },
                        },
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri(AppSettings.IdentityServerAuthentication.Authority + "/connect/token", UriKind.Absolute),
                            Scopes = new Dictionary<string, string>
                            {
                                { "Bluestone.WebAPI", "Bluestone WebAPI" },
                            },
                        },
                    },
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Oidc",
                            },
                        }, new List<string>()
                    },
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });

            services.AddCaches(AppSettings.Caching);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUser, CurrentWebUser>();

            services.AddStorageManager(AppSettings.Storage);
            services.AddHtmlGenerator();
            services.AddDinkToPdfConverter();
            services.AddBluestoneLocalization();

            //services.AddMessageBusSender<FileUploadedEvent>(AppSettings.MessageBroker);
            //services.AddMessageBusSender<FileDeletedEvent>(AppSettings.MessageBroker);
            //services.AddMessageBusSender<EmailMessageCreatedEvent>(AppSettings.MessageBroker);
            //services.AddMessageBusSender<SmsMessageCreatedEvent>(AppSettings.MessageBroker);

            services.AddScoped(typeof(ICsvReader<>), typeof(CsvReader<>));
            services.AddScoped(typeof(ICsvWriter<>), typeof(CsvWriter<>));
            services.AddScoped<IExcelReader<List<ConfigurationEntry>>, ConfigurationEntryExcelReader>();
            services.AddScoped<IExcelWriter<List<ConfigurationEntry>>, ConfigurationEntryExcelWriter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDebuggingMiddleware();

            app.UseAccessTokenFromFormMiddleware();

            app.UseLoggingStatusCodeMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(AppSettings.CORS.AllowAnyOrigin ? "AllowAnyOrigin" : "AllowedOrigins");

            app.UseSecurityHeaders(AppSettings.SecurityHeaders);

            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.OAuthClientId("Swagger");
                setupAction.OAuthClientSecret("secret");
                setupAction.OAuthUsePkce();

                setupAction.SwaggerEndpoint(
                    "/swagger/Bluestone/swagger.json",
                    "Bluestone API");

                setupAction.RoutePrefix = string.Empty;

                setupAction.DefaultModelExpandDepth(2);
                setupAction.DefaultModelRendering(ModelRendering.Model);
                setupAction.DocExpansion(DocExpansion.None);
                setupAction.EnableDeepLinking();
                setupAction.DisplayOperationId();
            });

            app.UseJwtMiddleware();
            app.UseAuthorization();

            app.UseMonitoringServices(AppSettings.Monitoring);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/hubs/notification").RequireCors("SignalRHubs");
            });
        }
    }
}
