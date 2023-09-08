


using Application.UserTgs.Interfaces;

namespace Application.UserTgs.Commands
{
    public class GetUserTgQuery : IGetUserTgQuery
    {
        private readonly IParserDbContext _context;


        public GetUserTgQuery(IParserDbContext context)
        {
            _context = context;
        }

        public async Task<UserTg?> GetUserTgQueryAsync(long chatid)
        {
            UserTg? user = await _context
        .Users
        .SingleOrDefaultAsync(u => u.ChatId == chatid);
            if (user != null) 
            {
                return user;
            }
            else return null;
        }
    }
}
