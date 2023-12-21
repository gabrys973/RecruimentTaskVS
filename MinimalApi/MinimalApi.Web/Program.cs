using MinimalApi.Web.Authorization;
using MinimalApi.Web.Authorization.Services;
using MinimalApi.Web.Endpoints.Documents;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<BasicAuthMiddleware>();

app.RegisterDocumentEndpoints();

app.Run();