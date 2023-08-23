

namespace Application.TypeService.Commands
{
    public class DeleteTypeServiceCommand : IDeleteEntityCommand
    {
        private readonly IParserDbContext _context;

        public DeleteTypeServiceCommand(IParserDbContext context)
        {
            _context = context;
        }
        
        public async Task DeleteEntityAsync(bool isdeleted, long chatid)
        {
            typeTg? type = await _context
                .types
                .SingleOrDefaultAsync(u => u.ChatId = chatid);
            if (type != null) 
            {
                type.IsDeleted = true;
                await _context.SaveChangeAsync();
            }
            else throw new NullReferenceException();
        }
    }
}
