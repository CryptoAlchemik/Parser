


namespace Application.Common.Interfaces
{
    public interface IParserDbContext
    {
        DbSet<Feedback> Feedbacks { get; }
        DbSet<Message> Messages { get; }
        DbSet<Service> Services { get; }
        DbSet<SubType> Subtypes { get; }
        DbSet<Type> Types { get; }
        DbSet<UserTg> Users { get; }

        Task SaveChangeAsync();
    }

}
