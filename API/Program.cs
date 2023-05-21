using API.Extensions;
using Application.Users;
// using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationService(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


// generating app object like express
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// this line add cors policy, hence our browser allow to send request on this code
// here bcz, it would be done before authentication and after app was created
app.UseCors("CorsPolicy");

// for check authantication purpose
app.UseAuthorization();

// map Controllers with some events
app.MapControllers();

// when load our aplication at that time our database get update
// use using bcz when we compelet use of scope that is automatically deleted
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    // this code is for generating the database
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync(); // if database is not present then it is create new one otherwise update previous one

    // add data into database
    await Seed.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
    throw;
}

app.Run();
