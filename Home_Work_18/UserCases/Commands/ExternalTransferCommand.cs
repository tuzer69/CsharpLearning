using System.Threading;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using HomeWork.Entities;
using MediatR;
using UseCases.Interfeces;

namespace UseCases.Commands
{
    public class ExternalTransferCommand : IRequestHandler<ExternalTransferCommand.Command>
    {
        private readonly IDbContext _context;

        public ExternalTransferCommand(IDbContext context) => _context = context;

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