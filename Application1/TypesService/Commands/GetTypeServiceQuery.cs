


namespace Application.TypeService.Commands
{
    public class GetTypeServiceQuery<T> : IGetEntityQuery<UserTg> where T : UserTg
    {
        private readonly IParserDbContext _context;


        public GetTypeServiceQuery(IParserDbContext context)
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
