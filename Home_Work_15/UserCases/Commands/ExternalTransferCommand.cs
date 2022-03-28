using System.Threading;
using System.Threading.Tasks;
using HomeWork.Entities;
using MediatR;
using UseCases.Interfeces;

namespace UseCases.Commands
{
    public class ExternalTransferCommand : IRequestHandler<ExternalTransferCommand.Command>
    {
        private readonly IReposytory<Client> _reposytory;

        public ExternalTransferCommand(IReposytory<Client> reposytory) => _reposytory = reposytory;

        public class Command : IRequest
        {
            public IAccount From { get; set; }
            public IAccount To { get; set; }
            public long Amount { get; set; }
        }

        public Task<Unit> Handle(Command request, CancellationToken cToken)
        {
            request.From.ExternalTransfer(request.To, request.Amount);

            return Task.FromResult(Unit.Value);
        }
    }

}