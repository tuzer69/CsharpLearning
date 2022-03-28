using System.Threading;
using System.Threading.Tasks;
using HomeWork.Entities;
using MediatR;
using UseCases.Interfeces;

namespace UseCases.Commands
{
    public class AddSimpleAccountCommand : IRequestHandler<AddSimpleAccountCommand.Command>
    {
        private readonly IReposytory<Client> _reposytory;

        public AddSimpleAccountCommand(IReposytory<Client> reposytory) => _reposytory = reposytory;

        public class Command : IRequest
        {
            public IClient Client { get; set; }
        }

        public Task<Unit> Handle(Command request, CancellationToken cToken)
        {
            request.Client.AddSimpleAccount();

            return Task.FromResult(Unit.Value);
        }
    }
}