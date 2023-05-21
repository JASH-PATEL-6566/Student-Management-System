using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users
{
    public class Delete
    {
        public class Query : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FindAsync(request.Id);

                _context.Remove(user);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}