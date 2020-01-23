# QuinnoxCoreApi
 
**Swagger** 
https://localhost:44330/swagger/index.html

**Log**
Logging: Nlog
settings:nlog.config
Is is saving on c:\temp

**Api Seeting**
Settings :
Omdb base address and key :
Located at  appsettings.json

  "AppSettings": {
    "OmdbBaseAddress": "http://www.omdbapi.com",
    "apiKey": "b473dec9"



**Windows form Http Client Base settings:**
Settings locate app.config

<add key="baseAddress" value="https://localhost:44330/api/"/>


# TODO:
**Core Api:** 
        -Create controler for single movie. Is is only implemented the search of movies.
        -Unit tests for controllers
        -Implement Log at global exception level

**Winform :** 
        -Implement async call and grid for single movie
        -implement Nlog


