namespace Tests.BLL.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
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
