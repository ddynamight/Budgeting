using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Elements;
using Budgeting.Domain.Events.Elements;
using Budgeting.Presentation.Elements.Commands;
using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Commands
{
     public class CreateElementCommandHandler : IRequestHandler<CreateElementCommand, CreateElementCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public CreateElementCommandHandler(IAppDbContext _context, IMapper _mapper, IMediator _mediator)
          {
               this._context = _context;
               this._mapper = _mapper;
               this._mediator = _mediator;
          }

          public async Task<CreateElementCommandResult> Handle(CreateElementCommand request, CancellationToken cancellationToken)
          {
               var element = _mapper.Map<Element>(request);
               element.Date = DateTime.Now;
               element.AddDomainEvent(new ElementCreatedEvent(element));
               await _context.Elements.AddAsync(element, cancellationToken);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new ElementCreatedEvent(element), cancellationToken);

               return _mapper.Map(element, new CreateElementCommandResult());
          }
     }
}