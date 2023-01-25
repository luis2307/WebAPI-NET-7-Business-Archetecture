FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-dev
WORKDIR /src
COPY . .
WORKDIR /src/Company.ProjectName.Services.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY --from=build-dev /src/Company.ProjectName.Services.WebApi/out ./
ENTRYPOINT ["dotnet", "Company.ProjectName.Services.WebApi.dll"]

 