using Offers.API.Repositories.Abstractions;
using Offers.API.Repositories.Implementations;
using System.Data.SqlClient;
using System.Data;
using FluentValidation;
using MediatR;
using Offers.API.Behaviors;
using Offers.Shared.Commands;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferItemRepository, OfferItemRepository>();

//builder.Services.AddTransient<IValidator<CreateOfferCommand>, CreateOfferCommandValidator>();
//builder.Services.AddTransient<IValidator<UpdateOfferCommand>, UpdateOfferCommandValidator>();
//builder.Services.AddTransient<IValidator<CreateOfferItemCommand>, CreateOfferItemCommandValidator>();
//builder.Services.AddTransient<IValidator<CreateOfferItemCommand>, CreateOfferItemCommandValidator>();


builder.Services.AddMediatR(opt =>
{
    opt.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    //opt.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
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
