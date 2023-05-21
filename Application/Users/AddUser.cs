using MediatR;
using Persistence;
using Domain;

namespace Application.Users
{
    public class AddUser
    {
        public class Command : IRequest
        {
            public User User { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {

            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // var username = request.User.Username;

                // var present = await _context.Users.FindAsync(request.User.Username);

                // if (present == null)
                // {
                _context.Users.Add(request.User);
                // await _context.SaveChangesAsync();
                // }

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}