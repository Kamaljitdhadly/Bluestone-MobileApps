using Bluestone.Application.Common.Behaviours;
using Bluestone.Application.Common.Exceptions;
using Bluestone.Application.Facilities.Services;
using Bluestone.Application.Identity.Services;
using Bluestone.Application.Messages.Services;
using Bluestone.Application.Partners.Services;
using Bluestone.Application.Patients.Services;
using Bluestone.Application.Users.Services;
using Bluestone.Domain.Services.Facilities;
using Bluestone.Domain.Services.Identity;
using Bluestone.Domain.Services.Messages;
using Bluestone.Domain.Services.Partners;
using Bluestone.Domain.Services.Patients;
using Bluestone.Domain.Services.Users;
using FluentValidation.AspNetCore;
using MediatR;
using System;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, Action<Type, Type, ServiceLifetime> configureInterceptor = null)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly())
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<NotFoundException>())
                    .AddMediatR(Assembly.GetExecutingAssembly())
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>))
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<IPatientService, PatientService>()
                    .AddScoped<IFacilityService, FacilityService>()
                    .AddScoped<IPartnerService, PartnerService>()
                    .AddScoped<IMessageService, MessageService>()
                    .AddScoped<IIdentityService, IdentityService>()
                    .AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
