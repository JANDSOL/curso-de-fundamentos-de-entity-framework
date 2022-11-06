using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proj_tareas_categ.Contexts;
using proj_tareas_categ.Utils;
using Task = proj_tareas_categ.Models.Task;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<ContextTasks>(builder.Configuration.GetConnectionString("cntTasks"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] ContextTasks dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/get/tareas", async ([FromServices] ContextTasks dbContext) =>
{
    return Results.Ok(
        dbContext.Tasks
            .Include(p => p.Category)
            .Where(p => p.PriorityTask == Priority.Low
                || p.PriorityTask == Priority.High
            )
    );
});

app.MapPost("/api/post/tareas", async ([FromServices] ContextTasks dbContext, [FromBody] Task task) =>
{
    await dbContext.AddAsync(task);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
