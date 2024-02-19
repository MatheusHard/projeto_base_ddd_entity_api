using Entity.Entities;
using Entity.Entities.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configs
{
    public class Contexto : IdentityDbContext<User>
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                optionsBuilder.UseMySql(connectionString,
                            ServerVersion.AutoDetect(connectionString),
                            p => p.EnableRetryOnFailure(maxRetryCount: 3, ///Colocar quantidade de Retry
                                                        maxRetryDelay: TimeSpan.FromSeconds(4),
                                                        errorNumbersToAdd: null));
                base.OnConfiguring(optionsBuilder);

            }

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users").HasKey(u => u.Id);
            base.OnModelCreating(builder);
        }
        public string GetStringConnection() 
        {
            //TODO
            string strconn = "fffdadada";

            return strconn;
        }
    }
}
