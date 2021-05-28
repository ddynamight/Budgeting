using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Presentation.Elements.Models.Results;
using Budgeting.Presentation.Elements.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Elements.Handlers.Queries
{
    public class GetElementsQueryHandler : IRequestHandler<GetElementsQuery, List<GetElementQueryResult>>
    {
         private readonly IAppDbContext _context;
         private readonly IMapper _mapper;

         public GetElementsQueryHandler(IAppDbContext _context, IMapper _mapper)
         {
              this._context = _context;
              this._mapper = _mapper;
         }

         public async Task<List<GetElementQueryResult>> Handle(GetElementsQuery request, CancellationToken cancellationToken)
         {
              var elements = await _context.Elements.ToListAsync(cancellationToken);
              return _mapper.Map<List<GetElementQueryResult>>(elements);
         }
    }
}