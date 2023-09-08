
namespace Application.SubTypes.Commands
{
    public class UpdateSubTypeCommand<T> : IUpdateEntityCommand<SubType> where T : SubType
    {
        private readonly IParserDbContext _context;

        public UpdateSubTypeCommand(IParserDbContext context)
        { _context = context; }

        public async Task<SubType> UpdateEntitykAsync(SubType entity)
        {
            SubType? user = await _context
                .SubTypes
                .SingleOrDefaultAsync(u => u.Id == entity.Id);

            if (user != null)
            {
                user.SubTypeName = entity.SubTypeName;
                user.UpdateTime = entity.UpdateTime;
                user.IsDeleted = entity.IsDeleted;
 
                await _context.SaveChangeAsync();

                return user;
            }

            else throw new NullReferenceException();
        }


    }
}
