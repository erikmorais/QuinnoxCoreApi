# QuinnoxCoreApi
 
Swagger: 
https://localhost:44330/swagger/index.html

Logging: Nlog
settings:nlog.config
Is is saving on c:\temp

Settings :
Omdb base address and key :
Located at  appsettings.json

{
  "Logging": {
    "LogLevel": {
      "Default": "Trace",
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "AppSettings": {
    "OmdbBaseAddress": "http://www.omdbapi.com",
    "apiKey": "b473dec9"
  }
}


Windows form Http Client Base settings:
Settings locate app.config

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
    </startup>
   <appSettings>
    <add key="baseAddress" value="https://localhost:44330/api/"/>
  </appSettings>
</configuration>

#TODO:
Core Api: 
        -Create controler for single movie. Is is only implemented the search of movies.
        -Unit tests for controllers
        -Implement Log at global exception level

Winform : 
        -Implement async call and grid for single movie
        -implement Nlog


