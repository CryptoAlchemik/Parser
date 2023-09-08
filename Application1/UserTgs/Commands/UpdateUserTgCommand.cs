using Application.UserTgs.Interfaces;

namespace Application.UserTgs.Commands
{
    public class UpdateUserTgCommand<T> : IUpdateUserTgCommand<UserTg> where T : UserTg
    {
        private readonly IParserDbContext _context;

        public UpdateUserTgCommand(IParserDbContext context)
        { _context = context; }

        public async Task<UserTg> UpdateEntitykAsync(UserTg entity)
        {
            UserTg? user = await _context
                .Users
                .SingleOrDefaultAsync(u => u.ChatId == entity.ChatId);

            if (user != null)
            {
                user.IsKicked = entity.IsKicked;
                user.UserName = entity.UserName;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.UpdateTime = entity.UpdateTime;
                user.IsAdmin = entity.IsAdmin;
                user.IsDeleted = entity.IsDeleted;
                user.Notification = entity.Notification;
                user.Services = entity.Services;

                await _context.SaveChangeAsync();

                return user;
            }

            else throw new NullReferenceException();
        }

        public async Task<string> UpdateUserTgNameAsync(string userName, long chatId)
        {
            UserTg? user = await _context
                 .Users
                 .SingleOrDefaultAsync(u => u.ChatId == chatId);

            if (user != null)
            {
                user.UserName = userName;
                await _context.SaveChangeAsync();
                return user.UserName;
            }
            else throw new NullReferenceException();
        }
    }
}
