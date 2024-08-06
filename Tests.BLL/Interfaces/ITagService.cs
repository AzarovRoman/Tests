using Tests.BLL.Models;

namespace Tests.BLL.Interfaces
{
    public interface ITagService
    {
        /// <summary>
        /// Добавление тега в бд
        /// </summary>        
        void AddTag(TagModel model);

        /// <summary>
        /// Удаление тега из бд
        /// </summary>
        void DeleteTag(int id);

        /// <summary>
        /// Получение тега по id
        /// </summary>       
        TagModel GetTag(int id);
    }
}