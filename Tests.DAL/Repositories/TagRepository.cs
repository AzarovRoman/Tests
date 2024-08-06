using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.DAL.Entities;
using Tests.DAL.Interfaces;

namespace Tests.DAL.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly Context _context;

        public TagRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавление тега в бд
        /// </summary>      
        public int AddTag(Tag tag)
        {
            _context.Tags.Add(tag);
            return _context.SaveChanges();
        }

        /// <summary>
        /// Получение тега по id
        /// </summary>
        public Tag GetTagById(int id)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Id == id);
            return tag;
        }

        /// <summary>
        /// Удаление тега из бд
        /// </summary>        
        public int DeleteTag(Tag tag)
        {
            _context.Tags.Remove(tag);
            return _context.SaveChanges();
        }
    }
}

