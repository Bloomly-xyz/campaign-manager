# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . /app
# Copy csproj and restore as distinct layers
RUN  cd API/CampaignManager.Api/ && dotnet build --configuration Release && dotnet publish -r linux-x64 --configuration Release --output myapp
    
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
#RUN apt-get update && apt-get install -y libgdiplus
COPY --from=build-env /app/API/CampaignManager.Api/myapp/ /app/
EXPOSE 80
ENTRYPOINT ["dotnet", "CampaignManager.Api.dll"]
