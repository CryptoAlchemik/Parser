


namespace Application.UserTgs.Commands
{
    public class GetUserTgQuery<T> : IGetEntityQuery<UserTg> where T : UserTg
    {
        private readonly IParserDbContext _context;


        public GetUserTgQuery(IParserDbContext context)
        {
            _context = context;
        }

        public async Task<UserTg> GetEntityAsync(long chatid)
        {
            UserTg? user = await _context
        .Users
        .SingleOrDefaultAsync(u => u.ChatId == chatid);
            if (user != null) 
            {
                return user;
            }
            else throw new NullReferenceException();
        }
    }
}
