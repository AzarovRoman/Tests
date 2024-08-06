using Tests.DAL.Entities;

namespace Tests.DAL.Interfaces
{
    public interface ITagRepository
    {
        /// <summary>
        /// Добавление тега в бд
        /// </summary>      
        int AddTag(Tag tag);

        /// <summary>
        /// Удаление тега из бд
        /// </summary>        
        int DeleteTag(Tag tag);

        /// <summary>
        /// Получение тега по id
        /// </summary>
        Tag GetTagById(int id);
    }
}