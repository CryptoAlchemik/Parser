


namespace Application.SubTypes.Commands
{
    public class GetSubTypeQuery<T> : IGetEntityQuery<SubType> where T : SubType
    {
        private readonly IParserDbContext _context;


        public GetSubTypeQuery(IParserDbContext context)
        {
            _context = context;
        }

        public async Task<SubType> GetEntityAsync(long id)
        {
            SubType? type = await _context
        .SubTypes
        .SingleOrDefaultAsync(u => u.Id == id);
            if (type != null) 
            {
                return type;
            }
            else throw new NullReferenceException();
        }
    }
}
