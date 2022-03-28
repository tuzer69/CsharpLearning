using System.Threading;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using HomeWork.Entities;
using MediatR;

namespace UseCases.Commands
{
    public class AddDepositAccountCommand : IRequestHandler<AddDepositAccountCommand.Command>
    {

        private readonly IDbContext _context;

        public AddDepositAccountCommand(IDbContext context) => _context = context;

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