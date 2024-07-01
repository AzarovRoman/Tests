using Tests.DAL.Entities;

namespace Tests.DAL.Interfaces
{
    public interface IQuestionRepository
    {
        int AddQuestion(Question question);
        Question? GetQuestionById(int id);
    }
}