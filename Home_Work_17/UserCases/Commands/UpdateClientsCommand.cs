using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Entities;
using MediatR;
using UseCases.Interfeces;

namespace UseCases.Commands
{
    public class UpdateClientsCommand : IRequestHandler<UpdateClientsCommand.Command>
    {
        private readonly IReposytory<Client> _reposytory;

        public UpdateClientsCommand(IReposytory<Client> reposytory) => 
            _reposytory = reposytory;

        public class Command : IRequest
        {
            public List<Client> Clients { get; set; }
        }

        public Task<Unit> Handle(UpdateClientsCommand.Command request, 
            CancellationToken cToken)
        {
            _reposytory.Updatadatabase(request.Clients);

            return Task.FromResult(Unit.Value);
        }
    }
}