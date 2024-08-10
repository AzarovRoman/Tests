using Tests.DAL.Enums;

namespace Tests.BLL.Models
{
    public class QuestionModel
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
        public List<AnswerModel> Answers { get; set; }
        /// <summary>
        /// Тег вопроса
        /// </summary>
        public TagModel Tag { get; set; }
    }
}
