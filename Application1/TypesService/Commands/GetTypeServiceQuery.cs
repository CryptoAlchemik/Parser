﻿


namespace Application.TypeServices.Commands
{
    public class GetTypeServiceQuery<T> : IGetEntityQuery<TypeService> where T : TypeService
    {
        private readonly IParserDbContext _context;


        public GetTypeServiceQuery(IParserDbContext context)
        {
            _context = context;
        }

        public async Task<TypeService> GetEntityAsync(long id)
        {
            TypeService? type = await _context
        .TypesService
        .SingleOrDefaultAsync(u => u.Id == id);
            if (type != null) 
            {
                return type;
            }
            else throw new NullReferenceException();
        }
    }
}
