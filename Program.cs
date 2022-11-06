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
    return Results.Ok(dbContext.Tasks.Include(p => p.Category));
});

app.MapPost("/api/post/tareas", async ([FromServices] ContextTasks dbContext, [FromBody] Task task) =>
{
    await dbContext.AddAsync(task);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/put/tarea/{id}", async ([FromServices] ContextTasks dbContext, [FromBody] Task task, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);

    if (currentTask != null)
    {
        currentTask.CategoryId = task.CategoryId;
        currentTask.Title = task.Title;
        currentTask.Description = task.Description;
        currentTask.PriorityTask = task.PriorityTask;
        currentTask.Status = task.Status;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();

});

app.MapDelete("/api/delete/tarea={id}", async ([FromServices] ContextTasks dbContext, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);

    if (currentTask != null)
    {
        dbContext.Remove(currentTask);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();

});

app.Run();
