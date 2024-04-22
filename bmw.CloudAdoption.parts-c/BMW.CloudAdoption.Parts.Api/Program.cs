global using Microsoft.AspNetCore.Mvc;
global using Newtonsoft.Json;
global using Confluent.Kafka;
  
global using BMW.CloudAdoption.Parts.Api;
global using BMW.CloudAdoption.Parts.Api.Core;
global using BMW.CloudAdoption.Parts.Api.Enums;
global using BMW.CloudAdoption.Parts.Api.Messaging;
global using BMW.CloudAdoption.Parts.Api.Models;
global using BMW.CloudAdoption.Parts.Api.Repositories;
global using BMW.CloudAdoption.Parts.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices();

var app = builder.Build();
await app.RunMigrationsAsync();
app.ConfigureApp();

app.MapGet("/", () => Results.Ok());

app.Run();
