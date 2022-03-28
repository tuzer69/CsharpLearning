using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using AutoMapper;
using DataAccess.Interfaces;
using HomeWork.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.Dto;
using UseCases.Interfeces;

namespace UseCases.Queries
{
    public class GetListClientsQuery : 
        IRequestHandler<GetListClientsQuery.Command, List<ClientDto>>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetListClientsQuery(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public class Command : IRequest<List<ClientDto>>
        {
        }

        public Task<List<ClientDto>> Handle(Command request, 
            CancellationToken token)
        {
            var clients = _context.Clients
                .Include(x => x.Accounts).ToList();

            var result = _mapper.Map<List<ClientDto>>(clients);

            return Task.FromResult(result);
        }
    }
}