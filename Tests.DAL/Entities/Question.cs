using Tests.DAL.Enums;

namespace Tests.DAL.Entities
{
    public class Question
    {
        public int Id { get; set; }
        /// <summary>
        /// Сложность вопроса, где 0 - легко, 1 - средне, 2 - тяжело
        /// </summary>
        public DifficultyEnum Difficulty { get; set; }
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Список ответов к вопросу
        /// </summary>
        public ICollection<Answer> Answers { get; set; }
        /// <summary>
        /// Тег вопроса
        /// </summary>
        public Tag? Tag { get; set; }
    }
}
