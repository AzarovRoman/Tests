using Tests.DAL.Entities;

namespace Tests.DAL.Interfaces
{
    public interface IQuestionRepository
    {
        int AddQuestion(Question question);

        /// <summary>
        /// Получение рандомного вопроса из базы данных
        /// </summary>        
        Question GetRandomQuestion();

        /// <summary>
        /// Получение вопроса по id
        /// </summary>      
        Question? GetQuestionById(int id);

        /// <summary>
        /// Удаление сущности вопроса из базы данных по id
        /// </summary>       
        int DeleteQuestion(int id);

    }
}