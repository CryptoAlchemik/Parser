using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class ParserDbContext : DbContext, IParserDbContext
    {
        public DbSet<Feedback> Feedbacks
        {
            get 
            {
                return Set<Feedback>();
            }
        }

        public DbSet<MessageBot> Messages => Set<MessageBot>();

        public DbSet<Service> Services => Set<Service>();

        public DbSet<SubType> SubTypes => Set<SubType>();

        public DbSet<TypeService> TypesService => Set<TypeService>();

        public DbSet<UserTg> Users => Set<UserTg>();

        public async Task SaveChangeAsync()
        {
           await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres;Trust Server Certificate=true");

            optionsBuilder.LogTo(Console.WriteLine);

        }

    }
}