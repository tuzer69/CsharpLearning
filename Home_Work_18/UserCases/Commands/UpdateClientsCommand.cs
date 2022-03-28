using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Interfaces;
using HomeWork.Entities;
using MediatR;
using UseCases.Dto;
using UseCases.Interfeces;

namespace UseCases.Commands
{
    public class UpdateClientsCommand : IRequestHandler<UpdateClientsCommand.Command>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public UpdateClientsCommand(IDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public class Command : IRequest
        {
            public List<ClientDto> Clients { get; set; }
        }

        public Task<Unit> Handle(Command request, 
            CancellationToken cToken)
        {
            var clients = _mapper.Map<List<Client>>(request.Clients);

            _context.SaveChange(clients);

            return Task.FromResult(Unit.Value);
        }
    }
}