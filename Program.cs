using System.Net;
using Microsoft.AspNetCore.Diagnostics;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler(
 options => {
    options.Run(
    async context =>
    {
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      context.Response.ContentType = "text/html";
      var ex = context.Features.Get<IExceptionHandlerFeature>();
      if (ex != null)
      {
       // var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
       var err = $"<h1>Error: {ex.Error.Message}</h1>";
        await context.Response.WriteAsync(err).ConfigureAwait(false);
      }
    });
 }
);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
