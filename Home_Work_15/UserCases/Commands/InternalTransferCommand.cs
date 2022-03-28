using System.Threading;
using System.Threading.Tasks;
using HomeWork.Entities;
using MediatR;
using UseCases.Interfeces;

namespace UseCases.Commands
{
    public class InternalTransferCommand : IRequestHandler<InternalTransferCommand.Command>
    {
        private readonly IReposytory<Client> _reposytory;

        public InternalTransferCommand(IReposytory<Client> reposytory) => _reposytory = reposytory;

        public class Command : IRequest
        {
            public IAccount From { get; set; }
            public IAccount To { get; set; }
            public long Amount { get; set; }
        }

        public Task<Unit> Handle(Command request, CancellationToken cToken)
        {
            request.From.BalanceTransfer(request.To, request.Amount);

            return Task.FromResult(Unit.Value);
        }
    }

}