using Budgeting.Presentation.Budgets.Commands;
using Budgeting.Presentation.Budgets.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Budgeting.Web.Controllers
{
     public class BudgetsController : Controller
     {
          private readonly ILogger<BudgetsController> _logger;
          private readonly IMediator _mediator;

          public BudgetsController(ILogger<BudgetsController> _logger, IMediator _mediator)
          {
               this._logger = _logger;
               this._mediator = _mediator;
          }


          public async Task<IActionResult> Index()
          {
               return View(await _mediator.Send(new GetBudgetsQuery()));
          }

          [HttpGet("Add")]
          public async Task<IActionResult> Add()
          {
               return View(new CreateBudgetCommand());
          }

          [HttpPost("Add")]
          public async Task<IActionResult> Add(CreateBudgetCommand command)
          {
               return View(await _mediator.Send(command));
          }

          [HttpGet("Details/{id}")]
          public async Task<IActionResult> Details(Guid id)
          {
               return View(await _mediator.Send(new GetBudgetQuery() { Id = id }));
          }

          [HttpGet("Edit/{id}")]
          public async Task<IActionResult> Edit(Guid id)
          {
               return View(await _mediator.Send(new GetBudgetQuery() { Id = id }));
          }

          [HttpPost("Edit/{id}")]
          public async Task<IActionResult> Edit(UpdateBudgetCommand command, Guid id)
          {
               return View(await _mediator.Send(command));
          }

          [HttpGet("Delete/{id}")]
          public async Task<IActionResult> Delete(Guid id)
          {
               return View(await _mediator.Send(new GetBudgetQuery() { Id = id }));
          }

          [HttpPost("Delete/{id}")]
          public async Task<IActionResult> Delete(DeleteBudgetCommand command, Guid id)
          {
               return View(await _mediator.Send(command));
          }
     }
}