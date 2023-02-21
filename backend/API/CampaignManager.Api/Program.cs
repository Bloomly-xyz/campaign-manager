
using CampaignManager.Api.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
await builder.RegisterAllDIServices();
builder.Services.Configure<FormOptions>(x =>
{
    x.ValueLengthLimit = int.MaxValue;
    x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
});
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set 
                                                      //default value is: 30 MB
});
var app = builder.Build();
app.UseHttpLogging();
app.UseCors(options => options
             .SetIsOriginAllowedToAllowWildcardSubdomains()
             .WithOrigins(
                          "http://localhost:3000",
                          "http://localhost:3001",
                          "http://localhost:3002",
                          "http://localhost:3003",
                          "http://localhost:8080",
                          "http://*.localhost:8080", 
                          "http://*.localhost:3001",
                          "http://*.localhost:3002",
                          "https://*.troonlab.io",
                          "https://*.troontech.com"
                          )
             .AllowAnyHeader()
             .AllowAnyMethod()
             .AllowCredentials()
         );

// Tells the application to transmit the cookie through HTTPS only.  
app.UseCookiePolicy(
new CookiePolicyOptions
{
    Secure = CookieSecurePolicy.Always
});
app.ConfigureExceptionHandler(app.Logger);
app.UseHttpsRedirection();
app.UseSession();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", string.Concat(builder.Configuration.GetValue<string>("Swagger:Title"), " ", builder.Configuration.GetValue<string>("Swagger:Version")));
    c.DocumentTitle = "Campaign Manager APIs";
});
app.UseReDoc(options =>
{
    options.DocumentTitle = "Campaign Manager APIs Documentation";
    options.SpecUrl = "/swagger/v1/swagger.json";
});
app.Use(async (context, next) =>
{
    var path = context.Request.Path;
    if (path.Value.Contains("/swagger/", StringComparison.OrdinalIgnoreCase))
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/login");
            return;
        }
        return;
    }

    await next();
});
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
