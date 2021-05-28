using AutoMapper;
using Budgeting.Application.Interfaces.Persistence;
using Budgeting.Presentation.Elements.Models.Results;
using Budgeting.Presentation.Elements.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Budgeting.Presentation.Documents.Handlers.Queries
{
     public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, List<GetDocumentQueryResult>>
     {
          private readonly IAppDbContext _context;
          private readonly IMapper _mapper;

          public GetDocumentsQueryHandler(IAppDbContext _context, IMapper _mapper)
          {
               this._context = _context;
               this._mapper = _mapper;
          }

          public async Task<List<GetDocumentQueryResult>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
          {
               var documents = await _context.Documents.ToListAsync(cancellationToken);
               return _mapper.Map<List<GetDocumentQueryResult>>(documents);
          }
     }
}