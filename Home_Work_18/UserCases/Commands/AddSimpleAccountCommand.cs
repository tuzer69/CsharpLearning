using System.Threading;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using HomeWork.Entities;
using MediatR;

namespace UseCases.Commands
{
    public class AddSimpleAccountCommand : IRequestHandler<AddSimpleAccountCommand.Command>
    {
        private readonly IDbContext _context;

        public AddSimpleAccountCommand(IDbContext context) => _context = context;

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