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
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<BookValidator>())
                .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<AuthorValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: myAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost").AllowAnyHeader().AllowAnyMethod();
        });
}); */
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options =>
    {
        options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
SQLConnection sqlConnection = builder.Configuration.GetSection("SQLConnection").Get<SQLConnection>();
builder.Services.AddScoped<IBaseRepository<Author>>(x => new AuthorRepository(sqlConnection));
builder.Services.AddScoped<IBaseRepository<Book>>(x => new BookRepository(sqlConnection));
builder.Services.AddScoped<IBaseRepository<Category>>(x => new CategoryRepository(sqlConnection));
builder.Services.AddScoped<ICategoryBookRepository>(x => new CategoryRepository(sqlConnection));

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

// app.UseCors(myAllowSpecificOrigins);

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
