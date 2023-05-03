using BookStore.Domain.Services;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Repositories;
using BookStore.Infrastructure.Interfaces;
using BookStore.API.Extensions;
using FluentValidation.AspNetCore;
using BookStore.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<BookValidator>())
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<AuthorValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
SQLConnection sqlConnection = builder.Configuration.GetSection("SQLConnection").Get<SQLConnection>();
builder.Services.AddScoped<IBaseRepository<Author>>(x => new AuthorRepository(sqlConnection));
builder.Services.AddScoped<IBaseRepository<Book>>(x => new BookRepository(sqlConnection));

builder.Services.UseCustomBadExceptionHandler();

var app = builder.Build();
app.UseCustomExceptionHandler();

app.Use(async (context, next) =>
{
    context.Request.EnableBuffering();
    await next();
});

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
