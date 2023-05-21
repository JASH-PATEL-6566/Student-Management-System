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
    public class Check
    {
        public class Query : IRequest<User>
        {
            public String LoginInfo { get; set; }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.LoginInfo.Contains("@"))
                {
                    var username = request.LoginInfo.Split("@")[0];
                    var password = request.LoginInfo.Split("@")[1];
                    return await Task.FromResult(_context.Users.FirstOrDefault(u => u.Username == username && u.Password == password)); ;
                }
                var id = Guid.Parse(request.LoginInfo);
                return await _context.Users.FindAsync(id);
            }
        }
    }
}