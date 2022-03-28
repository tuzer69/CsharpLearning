using System.Threading;
using System.Threading.Tasks;
using HomeWork.Entities;
using MediatR;
using UseCases.Interfeces;

namespace UseCases.Commands
{
    public class AddBalanceAccountCommand : IRequestHandler<AddBalanceAccountCommand.Command, Account>
    {
        private readonly IReposytory<Client> _reposytory;

        public AddBalanceAccountCommand(IReposytory<Client> reposytory) => _reposytory = reposytory;

        public class Command : IRequest<Account>
        {
            public IAccount Account { get; set; }
            public long Amount { get; set; }
        }

        public Task<Account> Handle(Command request, CancellationToken cToken)
        {
           var result = request.Account.AddBalance(request.Amount);

            return Task.FromResult(result);
        }
    }
}