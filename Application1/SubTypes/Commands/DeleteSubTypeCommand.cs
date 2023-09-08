

namespace Application.SubTypes.Commands
{
    public class DeleteSubTypeCommand : IDeleteEntityCommand
    {
        private readonly IParserDbContext _context;

        public DeleteSubTypeCommand(IParserDbContext context)
        {
            _context = context;
        }
        
        public async Task DeleteEntityAsync(bool isdeleted, long chatid)
        {
            SubType? type = await _context
                .SubTypes
                .SingleOrDefaultAsync(u => u.Id == chatid);
            if (type != null) 
            {
                type.IsDeleted = true;
                await _context.SaveChangeAsync();
            }
            else throw new NullReferenceException();
        }
    }
}
