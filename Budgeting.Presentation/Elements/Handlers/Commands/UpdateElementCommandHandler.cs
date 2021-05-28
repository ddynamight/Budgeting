using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Domain.Events.Elements;
using Budgeting.Presentation.Elements.Commands;
using Budgeting.Presentation.Elements.Models.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Commands
{
     public class UpdateElementCommandHandler : IRequestHandler<UpdateElementCommand, UpdateElementCommandResult>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public UpdateElementCommandHandler(IAppDbContext _context, IMapper _mapper, IMediator _mediator)
          {
               this._context = _context;
               this._mapper = _mapper;
               this._mediator = _mediator;
          }

          public async Task<UpdateElementCommandResult> Handle(UpdateElementCommand request, CancellationToken cancellationToken)
          {
               var elementFromDb = await _context.Elements.SingleAsync(e => e.Id.Equals(request.Id), cancellationToken);
               var element = _mapper.Map(request, elementFromDb);
               element.AddDomainEvent(new ElementUpdatedEvent(element));

               _context.Elements.Attach(element);
               await _context.SaveChangesAsync(cancellationToken);
               await _mediator.Publish(new ElementUpdatedEvent(element), cancellationToken);

               return _mapper.Map(element, new UpdateElementCommandResult());
          }
     }
}