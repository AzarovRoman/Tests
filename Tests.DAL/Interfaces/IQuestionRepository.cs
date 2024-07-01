using Tests.DAL.Entities;

namespace Tests.DAL.Interfaces
{
    public interface IQuestionRepository
    {
        int AddQuestion(Question question);
        /// <summary>
        /// Получение вопроса по id
        /// </summary>      
        Question? GetQuestionById(int id);
    }
}