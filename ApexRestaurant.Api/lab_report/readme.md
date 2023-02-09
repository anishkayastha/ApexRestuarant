# Lab Report

## Objectives
---

* to configure the web api connection and use Postman to test the api.

## Introduction
---

REST APIs work by sending HTTP requests to a server and receiving a response. Here's a simple example of how a REST API works:

* A client (such as a web browser or a mobile app) sends an HTTP request to a server with a specific URL endpoint.

* The server processes the request and returns an HTTP response, which typically includes a status code and a response body.

* The status code indicates the outcome of the request (e.g., 200 OK for a successful response, 404 Not Found if the requested resource is not found, etc.).

* The response body contains the data returned by the server in a specified format, such as JSON or XML.

The specific details of the request and response (such as the URL endpoint, the HTTP method, the request headers and body, etc.) depend on the API design. REST APIs use standard HTTP methods (GET, POST, PUT, DELETE, etc.) to perform operations on resources, and often return data in JSON format. RESTful API design follows the principles of REST, which include the use of a uniform interface, the use of stateless communication, and the ability to cache responses.

## Procedure
---

1. Navigate to “appsettings.json” file and add “ConnectionStrings” section:

        {
        "ConnectionStrings": {
            "DefaultConnection": "Server=DESKTOP-KAA28DH\\SQLEXPRESS;Database=ApexRestaurantDB;Trusted_Connection=True;TrustServerCertificate=True;"
        },
        "Logging": {
            "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
            }
        },
        "AllowedHosts": "*"
        }
2. Browse to "Program.cs," Add configuration entries for RepositoryModule and ServiceModule in the service container.

        using ApexRestaurant.Repository;
        using ApexRestaurant.Services;

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if(string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("Connection String not found in appsettings.json");
            return;
        }
        RepositoryModule.Register(builder.Services, connectionString, "ApexRestaurant.Api");

        ServicesModule.Register(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

3. Under “Controllers” folder, add “CustomerController.cs”

        using System.Threading;
        using ApexRestaurant.Repository.Domain;
        using ApexRestaurant.Services.SCustomer;
        using Microsoft.AspNetCore.Mvc;

        namespace ApexRestaurant.Api.Controller
        {
            [Route("api/customer")]
            public class CustomerController : ControllerBase
            {
                private readonly ICustomerService _customerService;
                public CustomerController(ICustomerService customerService)
                {
                    _customerService = customerService;
                }

                [HttpGet]
                [Route("{id}")]
                public IActionResult Get([FromRoute] int id)
                {
                    var customer = _customerService.GetById(id);
                    if (customer == null)
                        return NotFound();
                    return Ok(customer);
                }

                [HttpGet]
                [Route("")]
                public IActionResult GetAll()
                {
                    var customers = _customerService.GetAll();
                    return Ok(customers);
                }

                [HttpPost]
                [Route("")]
                public IActionResult Post([FromBody] Customer model)
                {
                    _customerService.Insert(model);
                    return Ok();
                }

                [HttpPut]
                [Route("")]
                public IActionResult Put([FromBody] Customer model)
                {
                    _customerService.Update(model);
                    return Ok();
                }

                [HttpDelete]
                [Route ("{id}")]
                public IActionResult Delete([FromRoute] int id) 
                {
                    _customerService.Delete(id);
                    return Ok();
                }
            }
        }

5. Add necessary dependencies to the project.

        dotnet add package Microsoft.EntityFrameworkCore
        dotnet add package Microsoft.EntityFrameworkCore.Abstractions
        dotnet add package Microsoft.EntityFrameworkCore.Analyzers
        dotnet add package Microsoft.EntityFrameworkCore.Relational
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer
        dotnet add package Microsoft.Extensions.Caching.Abstractions
        dotnet add package Microsoft.Extensions.Caching.Memory
        dotnet add package Microsoft.Extensions.Configuration
        dotnet add package Microsoft.Extensions.Configuration.Abstractions
        dotnet add package Microsoft.Extensions.Configuration.Binder
        dotnet add package Microsoft.Extensions.DependencyInjection
        dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
        dotnet add package Microsoft.Extensions.Logging
        dotnet add package Microsoft.Extensions.Logging.Abstractions
        dotnet add package Microsoft.Extensions.Options
        dotnet add package Microsoft.Extensions.Primitives

6. Build the project to ensure there are no errors.

## Output
---

![](image_01.png "image_01")
![](image_02.png "image_02")
![](image_03.png "image_03")
![](image_04.png "image_04")

## Conclusion
---

On this lab, we learned how to set up the connection and test the API using Postman. Understanding various request methods and status codes with particular messages.