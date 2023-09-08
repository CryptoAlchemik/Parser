﻿
namespace Application.TypeServices.Commands
{
    public class UpdateTypeServiceCommand<T> : IUpdateEntityCommand<TypeService> where T : TypeService
    {
        private readonly IParserDbContext _context;

        public UpdateTypeServiceCommand(IParserDbContext context)
        { _context = context; }

        public async Task<TypeService> UpdateEntitykAsync(TypeService entity)
        {
            TypeService? user = await _context
                .TypesService
                .SingleOrDefaultAsync(u => u.Id == entity.Id);

            if (user != null)
            {
                user.SubTypes = entity.SubTypes;
                user.TypeName = entity.TypeName;
                user.UpdateTime = entity.UpdateTime;
                user.IsDeleted = entity.IsDeleted;
 
                await _context.SaveChangeAsync();

                return user;
            }

            else throw new NullReferenceException();
        }


    }
}
