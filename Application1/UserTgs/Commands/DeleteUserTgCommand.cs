

namespace Application.UserTgs.Commands
{
    public class DeleteUserTgCommand : IDeleteEntityCommand
    {
        private readonly IParserDbContext _context;

        public DeleteUserTgCommand(IParserDbContext context)
        {
            _context = context;
        }
        
        public async Task DeleteEntityAsync(bool isdeleted, long chatid)
        {
            UserTg? user = await _context
                .Users
                .SingleOrDefaultAsync(u => u.ChatId == chatid);
            if (user != null) 
            {
                user.IsDeleted = true;
                await _context.SaveChangeAsync();
            }
            else throw new NullReferenceException();
        }
    }
}
