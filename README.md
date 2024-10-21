### DemoApi

This small project shows the ways with new approach to API UI in .NET 9. Swagger will be removed from the standard setup.

#### Open Api

To browse the documentation generated in json for the current API:
```
https://localhost:7227/openapi/v1.json
```
But there is no UI by default 

1. The Swagger could be added back
* Install the `Swashbuckle.AspNetCore` Nuget Package
* Add code:
```
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo Api");
    });
```
* Go to the link:

```
https://localhost:7227/swagger/index.html
```
2. Use other similar UI for API
* In this example we add package `Scalar.AspNetCore`
* Instead of Swagger, add in `Program.cs`:
```
app.MapScalarApiReference();
```
* Use different options to customise it