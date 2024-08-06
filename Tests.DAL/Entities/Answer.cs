
namespace Tests.DAL.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        /// <summary>
        /// Вопрос, к которому относится ответ
        /// </summary>
        public Question Question { get; set; }
        /// <summary>
        /// Текст ответа
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Обозначение правильности ответа
        /// </summary>
        public bool IsRight { get; set; }
    }
}
