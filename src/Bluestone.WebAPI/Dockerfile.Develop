FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /Bluestone

# Copy csproj and restore as distinct layers
COPY ./Bluestone.Application/*.csproj ./Bluestone.Application/
COPY ./Bluestone.CrossCuttingConcerns/*.csproj ./Bluestone.CrossCuttingConcerns/
COPY ./Bluestone.Domain/*.csproj ./Bluestone.Domain/
COPY ./Bluestone.Infrastructure/*.csproj ./Bluestone.Infrastructure/
COPY ./Bluestone.IntegrationTests/*.csproj ./Bluestone.IntegrationTests/
COPY ./Bluestone.Migrator/*.csproj ./Bluestone.Migrator/
COPY ./Bluestone.Persistence/*.csproj ./Bluestone.Persistence/
COPY ./Bluestone.UnitTests/*.csproj ./Bluestone.UnitTests/
COPY ./Bluestone.WebAPI/*.csproj ./Bluestone.WebAPI/
COPY ./Bluestone.sln .
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish ./Bluestone.WebAPI/Bluestone.WebAPI.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /Bluestone
COPY --from=build-env /Bluestone/out .

ENTRYPOINT ["dotnet", "Bluestone.WebAPI.dll"]