


namespace Application.TypeService.Commands
{
    public class CreateTypeServiceCommand<T> : ICeateEntityCommand<TypeService> where T : TypeService
    {
        private readonly IParserDbContext _context;

        public CreateTypeServiceCommand(IParserDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateEntityAsync(TypeService entity)
        {
            TypeService? type = new TypeService();

            if (entity != null)
            {
                type.TypeName = entity.TypeName;
                type.UpdateTime = entity.UpdateTime;
           

                await _context.SaveChangeAsync();

                return true;
            }
            else throw new NullReferenceException();
        }
    }
}
