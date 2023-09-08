


namespace Application.Common.Interfaces
{
    public interface IParserDbContext
    {
        DbSet<Feedback> Feedbacks { get; }
        DbSet<MessageBot> Messages { get; }
        DbSet<Service> Services { get; }
        DbSet<SubType> SubTypes { get; }
        DbSet<TypeService> TypesService { get; }
        DbSet<UserTg> Users { get; }

        Task SaveChangeAsync();
    }

}
