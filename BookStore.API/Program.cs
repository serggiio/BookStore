using BookStore.Domain.Services;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Repositories;
using BookStore.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthorService, AuthorService>();
SQLConnection sqlConnection = builder.Configuration.GetSection("SQLConnection").Get<SQLConnection>();
builder.Services.AddScoped<IBaseRepository<Author>>(x => new AuthorRepository(sqlConnection));

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
