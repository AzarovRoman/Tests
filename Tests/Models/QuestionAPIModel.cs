using Tests.DAL.Enums;

namespace Tests.Models
{
    public class QuestionAPIModel
    {
        public DifficultyEnum Difficulty { get; set; }
        public string Text { get; set; }
        public List<AnswerAPIModel> Answers { get; set; }
    }
}
