using System.Threading;
using System.Threading.Tasks;
using HomeWork.Entities;
using MediatR;
using UseCases.Interfeces;

namespace UseCases.Commands
{
    public class RemoveAccountCommand : IRequestHandler<RemoveAccountCommand.Command>
    {
        private readonly IReposytory<Client> _reposytory;

        public RemoveAccountCommand(IReposytory<Client> reposytory) => _reposytory = reposytory;

        public class Command : IRequest
        {
            public IClient Client { get; set; }
            public IAccount Account { get; set; }
        }

        public Task<Unit> Handle(Command request, CancellationToken cToken)
        {
            request.Client.RemoveAccount(request.Account);

            return Task.FromResult(Unit.Value);
        }
    }
}