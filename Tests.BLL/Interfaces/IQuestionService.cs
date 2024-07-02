using Tests.BLL.Models;

namespace Tests.BLL.Interfaces
{
    public interface IQuestionService
    {
        int AddQuestion(QuestionModel model);

        /// <summary>
        /// Получение вопроса по id
        /// </summary>      
        QuestionModel? GetQuestionById(int id);
    }
}