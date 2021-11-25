FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY publish/app/ ./app
WORKDIR /app
ENTRYPOINT ["dotnet", "FrontEndBackEndDemo.Api.dll"]