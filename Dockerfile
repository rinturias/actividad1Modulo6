FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-end
WORKDIR /app

COPY . .
RUN dotnet restore 
RUN dotnet publish ./Api.Gateway.Grupo1/Api.Gateway.Grupo1.csproj -c Release -o  /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 5223 443
ENV ASPNETCORE_URLS=http://*:5223
ENV ASPNETCORE_ENVIRONMENT=docker
COPY --from=build-end /app/publish .  

ENTRYPOINT ["dotnet", "Api.Gateway.Grupo1.dll"]