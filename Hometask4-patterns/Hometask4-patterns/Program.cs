using FluentValidation;
using FluentValidation.AspNetCore;
using Hometask4_patterns.Data.Context;
using Hometask4_patterns.Dto;
using Hometask4_patterns.Repository;
using Hometask4_patterns.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositoryLayers();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers().AddFluentValidation();


builder.Services.AddScoped<IValidator<BlogDto>, BlogValidator>();
builder.Services.AddScoped<IValidator<PostDto>, PostValidator>();

builder.Services.AddDbContext<AppDbContext>(opts =>
       opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
