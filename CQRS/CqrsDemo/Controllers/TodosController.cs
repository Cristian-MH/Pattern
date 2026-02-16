using CqrsDemo.Application.Commands.CompleteTodo;
using CqrsDemo.Application.Commands.CreateTodo;
using CqrsDemo.Application.Queries.GetTodoById;
using CqrsDemo.Application.Queries.ListTodos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDemo.Controllers;

[ApiController]
[Route("api/todos")]
public sealed class TodosController : ControllerBase
{
    private readonly IMediator _mediator;
    public TodosController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateTodoRequest req, CancellationToken ct)
    {
        var id = await _mediator.Send(new CreateTodoCommand(req.Title), ct);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPost("{id:guid}/complete")]
    public async Task<IActionResult> Complete(Guid id, CancellationToken ct)
    {
        await _mediator.Send(new CompleteTodoCommand(id), ct);
        return NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var dto = await _mediator.Send(new GetTodoByIdQuery(id), ct);
        return dto is null ? NotFound() : Ok(dto);
    }

    [HttpGet]
    public async Task<IActionResult> List(CancellationToken ct)
    {
        var list = await _mediator.Send(new ListTodosQuery(), ct);
        return Ok(list);
    }
}

public sealed record CreateTodoRequest(string Title);
