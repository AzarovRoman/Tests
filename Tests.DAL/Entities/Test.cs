
namespace Tests.DAL.Entities
{
    public class Test
    {
        public int Id { get; set; }
        /// <summary>
        /// Список вопросов теста
        /// </summary>
        public List<Question> Questions { get; set; }
        /// <summary>
        /// Название теста
        /// </summary>
        public string Name { get; set; }
    }
}
