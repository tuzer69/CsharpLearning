using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HomeWork.Entities;
using MediatR;
using UseCases.Interfeces;

namespace UseCases.Queries
{
    public class GetListClientsQuery : 
        IRequestHandler<GetListClientsQuery.Command, List<Client>>
    {
        private readonly IReposytory<Client> _reposytory;

        public GetListClientsQuery(IReposytory<Client> reposytory) => _reposytory = reposytory;


        public class Command : IRequest<List<Client>>
        {
        }

        public Task<List<Client>> Handle(Command request, 
            CancellationToken cancellationToken)
        {
            var clients = _reposytory.GetClients();

            return Task.FromResult(clients);
        }
    }
}