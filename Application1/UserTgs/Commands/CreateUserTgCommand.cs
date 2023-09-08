
namespace Application.UserTgs.Commands
{
    public class CreateUserTgCommand<T> : ICeateEntityCommand<UserTg> where T : UserTg
    {
        private readonly IParserDbContext _context;

        public CreateUserTgCommand(IParserDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateEntityAsync(UserTg entity)
        {
            
            var existingUser = new GetUserTgQuery(_context);
            var check = await existingUser.GetUserTgQueryAsync(entity.ChatId);

            UserTg? user = new UserTg();

                if (entity != null && check == null)
                {
                    user.UserName = entity.UserName;
                    user.FirstName = entity.FirstName;
                    user.LastName = entity.LastName;
                    user.UpdateTime = entity.UpdateTime;
                    user.ChatId = entity.ChatId;

                    await _context.Users.AddAsync(user);

                    await _context.SaveChangeAsync();

                    return true;
                }
                else throw new NullReferenceException();
            
        }
    }
}
