using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Reflection;

namespace Application.Common.Abstract
{
    public class CreateEntityCommand<T> : ICeateEntityCommand<T> where T : class
    {
        private readonly IParserDbContext _context;

        public CreateEntityCommand(IParserDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateEntityAsync(T entity)
        {
           // T? subtype = new T();

            Type reflType = typeof(T);

            if (entity != null)
            {
                foreach (PropertyInfo prop in reflType.GetProperties())
                {
                    var propname = reflType.GetProperty(prop.Name);

                 //  propname.SetValue(subtype, entity, null);

                }


                await _context.SaveChangeAsync();

                return true;
            }
            else throw new NullReferenceException();
        }
    }
}
