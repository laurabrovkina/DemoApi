using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey("ForTheLoveOfGodStoreAndLoadThisSecurely"u8.ToArray()),
            ValidIssuer = "https://id.dometrain.com",
            ValidAudience = "https://dometrain.com",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidateAudience = true
        };
    });

var app = builder.Build();

app.UseAuthorization();
app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Demo Api")
            .WithTheme(ScalarTheme.Purple)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
            .WithDarkModeToggle(true)
            .WithPreferredScheme("ApiKey")
            .WithApiKeyAuthentication(x => x.Token = "my-api-key");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
