using MinimalApi.Application.Services.Documents;
using MinimalApi.Web.Authorization;
using MinimalApi.Web.Authorization.Services;
using MinimalApi.Web.Configuration.Exceptions;
using MinimalApi.Web.Endpoints.Documents;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

builder.Logging.ClearProviders();
Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<BasicAuthMiddleware>();
app.UseMiddleware<ExceptionHandleMiddleware>();

app.RegisterDocumentEndpoints();

app.Run();

//