﻿

namespace Application.TypeServices.Commands
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
            TypeService? type = await _context
                .TypesService
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
