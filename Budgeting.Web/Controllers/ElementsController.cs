using Budgeting.Presentation.Elements.Commands;
using Budgeting.Presentation.Elements.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Budgeting.Web.Controllers
{
     public class ElementsController
     {
          private readonly ILogger<ElementsController> _logger;
          private readonly IMediator _mediator;

          public ElementsController(ILogger<ElementsController> _logger, IMediator _mediator)
          {
               this._logger = _logger;
               this._mediator = _mediator;
          }

          public async Task<IActionResult> Index()
          {
               return View(await _mediator.Send(new GetElementsQuery()));
          }

          [HttpGet("Add")]
          public async Task<IActionResult> Add()
          {
               return View(new CreateElementCommand());
          }

          [HttpPost("Add")]
          public async Task<IActionResult> Add(CreateElementCommand command)
          {
               return View(await _mediator.Send(command));
          }

          [HttpGet("Details/{id}")]
          public async Task<IActionResult> Details(Guid id)
          {
               return View(await _mediator.Send(new GetElementQuery() { Id = id }));
          }

          [HttpGet("Edit/{id}")]
          public async Task<IActionResult> Edit(Guid id)
          {
               return View(await _mediator.Send(new GetElementQuery() { Id = id }));
          }

          [HttpPost("Edit/{id}")]
          public async Task<IActionResult> Edit(UpdateElementCommand command, Guid id)
          {
               return View(await _mediator.Send(command));
          }

          [HttpGet("Delete/{id}")]
          public async Task<IActionResult> Delete(Guid id)
          {
               return View(await _mediator.Send(new GetElementQuery() { Id = id }));
          }

          [HttpPost("Delete/{id}")]
          public async Task<IActionResult> Delete(DeleteElementCommand command, Guid id)
          {
               return View(await _mediator.Send(command));
          }
     }
}
