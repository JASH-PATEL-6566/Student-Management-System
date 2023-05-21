using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Users.Any()) return;

            var users = new List<User>
        {
            new User
                {
                    Username = "Jash",
                    Email = "jash@jash.com",
                    Password = "123",
                    Standard = "10",
                    Gender = "Male"
                }
        };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}