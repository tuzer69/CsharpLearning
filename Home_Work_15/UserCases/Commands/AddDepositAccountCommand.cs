using System.Threading;
using System.Threading.Tasks;
using HomeWork.Entities;
using MediatR;
using UseCases.Interfeces;

namespace UseCases.Commands
{
    public class AddDepositAccountCommand : IRequestHandler<AddDepositAccountCommand.Command>
    {
        private readonly IReposytory<Client> _reposytory;

        public AddDepositAccountCommand(IReposytory<Client> reposytory) => _reposytory = reposytory;

        public class Command : IRequest
        {
            public IClient Client { get; set; }
        }

        public Task<Unit> Handle(Command request, CancellationToken cToken)
        {
            request.Client.AddDepositAccount();

            return Task.FromResult(Unit.Value);
        }
    }
}