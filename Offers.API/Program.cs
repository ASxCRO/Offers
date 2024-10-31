using Offers.API.Repositories.Abstractions;
using Offers.API.Repositories.Implementations;
using System.Data.SqlClient;
using System.Data;
using FastEndpoints;
using Offers.API.Utils;
using System.Reflection;
using Offers.Shared.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferItemRepository, OfferItemRepository>();

builder.Services.AddFluentValidationFromAssembly(typeof(CreateOfferCommand).Assembly);

builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddFastEndpoints();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors", builder =>
    {
        builder.AllowAnyOrigin() 
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowCors");
app.UseFastEndpoints();

app.Run();
