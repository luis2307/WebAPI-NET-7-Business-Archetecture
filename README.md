# WebAPI-NET-7-Business-Archetecture [![.NET](https://github.com/luis2307/WebAPI-NET-7-Business-Archetecture/actions/workflows/dotnet.yml/badge.svg)](https://github.com/luis2307/WebAPI-NET-7-Business-Archetecture/actions/workflows/dotnet.yml)


This project contains a clean architecture of a web API with .NET 7 following best practices such as SOLID, Design Patterns, and decoupling, among others. You can use it in your projects and improve it as you like but don't forget to use tags.  

## In this project you will find :

- REST API
- .NET 7
- Swagger
- OpenAPI
- Dapper
- JWT Token Authentication following OAuth 2.0 standards
- Example of unit testing with the MSTest Library
- Database script
- Repository Design Pattern 
- Unit of work design pattern
- Dependency injection
- Refactoring. 
- HealthChecks services to know the health status of the APP.
- WatchDog to monitor your application in real-time.

> I will continue to add more features in the future and I will continue to update the documentation.


## Redis in Docker:
```
docker run -d --name redis-stack -e REDIS_ARGS="--requirepass {your hard passwork here}" -p 6379:6379 -p 8001:8001 redis/redis-stack:latest
 ```
>Open Redis Browser http://localhost:8001/ 

>Username: default

>Password: You have set it up
 
Cheers!
