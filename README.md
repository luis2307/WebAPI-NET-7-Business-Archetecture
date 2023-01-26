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

## Rate limiting:

#### Types of rate limiters


* [Concurrency limit](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/#concurrency-limit)  is the simplest form of rate limiting. It doesn’t look at time, just at number of concurrent requests. “Allow 10 concurrent requests”.

* [Fixed window limit](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/#fixed-window-limit)  lets you apply limits such as “60 requests per minute”. Every minute, 60 requests can be made. One every second, but also 60 in one go.

* [Sliding window limit](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/#sliding-window-limit)  is similar to the fixed window limit, but uses segments for more fine-grained limits. Think “60 requests per minute, with 1 request per second”.

* [Token bucket limit](https://devblogs.microsoft.com/dotnet/announcing-rate-limiting-for-dotnet/#token-bucket-limit)  lets you control flow rate, and allows for bursts. Think “you are given 100 requests every minute”. If you make all of them over 10 seconds, you’ll have to wait for 1 minute before you are allowed more requests.

 [Documentation](https://blog.maartenballiauw.be/post/2022/09/26/aspnet-core-rate-limiting-middleware.html)



 
Cheers!
