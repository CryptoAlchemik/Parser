namespace Application.SubTypes.Commands
{
    public class CreateSubTypeCommand<T> : ICeateEntityCommand<SubType> where T : SubType
    {
        private readonly IParserDbContext _context;

        public CreateSubTypeCommand(IParserDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateEntityAsync(SubType entity)
        {
            SubType? type = new SubType();

            if (entity != null)
            {
                type.SubTypeName = entity.SubTypeName;
                type.UpdateTime = entity.UpdateTime;


                await _context.SaveChangeAsync();

                return true;
            }
            else throw new NullReferenceException();
        }
    }
}
