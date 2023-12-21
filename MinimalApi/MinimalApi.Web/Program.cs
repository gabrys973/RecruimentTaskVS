using Microsoft.AspNetCore.Mvc;
using MinimalApi.Web.Authorization;
using MinimalApi.Web.Authorization.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<BasicAuthMiddleware>();

app.MapPost("/api/test/{x}", ([FromRoute] int x) => x);

app.Run();