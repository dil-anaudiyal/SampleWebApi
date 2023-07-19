using BookManager;
using BookManager.Context;
using BookManager.Extensions;
using BookManager.Migrations;
using FluentMigrator.Runner;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<Database>();
builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
.AddFluentMigratorCore()
        .ConfigureRunner(c => c.AddSqlServer2016()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Booksdb"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());

builder.Services.AddScoped<BookService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build().MigrateDatabase();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
