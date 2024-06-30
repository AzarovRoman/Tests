
namespace Tests.DAL.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Difficulty { get; set; }
        public string Text { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
