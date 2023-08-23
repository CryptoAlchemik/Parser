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

        public DbSet<Message> Messages => Set<Message>();

        public DbSet<Service> Services => Set<Service>();

        public DbSet<SubType> Subtypes => Set<SubType>();

        public DbSet<Type> Types => Set<Type>();

        public DbSet<UserTg> Users => Set<UserTg>();

        public async Task SaveChangeAsync()
        {
           await base.SaveChangesAsync();
        }
        
    }
}