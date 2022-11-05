using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proj_tareas_categ.Contexts;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<ContextTasks>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<ContextTasks>("Data Source=JUAN-IS-COMPUTE\\JANDRADES;Initial Catalog=TasksDb;Trusted_Connection=True; Integrated Security=True");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] ContextTasks dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.Run();
