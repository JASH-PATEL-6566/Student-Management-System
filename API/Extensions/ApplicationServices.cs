using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // connection with database
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });


            // this is a code by which you can set cors policy 
            // set cor policy which can allow localhost:3000 , allow all kind of header and method
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });

            services.AddMediatR(typeof(AddUser.Handler));
            services.AddMediatR(typeof(List.Handler));

            // register our mapping profile
            // services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}
