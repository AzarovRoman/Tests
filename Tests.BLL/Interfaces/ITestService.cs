using Tests.BLL.Models;

namespace Tests.BLL.Interfaces
{
    public interface ITestService
    {
        /// <summary>
        /// Метод добавляет тест в базу данных
        /// </summary>        
        void AddTest(TestModel test);

        /// <summary>
        /// Метод добавляет тест с уже существующими вопросами в базу данных
        /// </summary>
        /// <param name="test"></param>
        int AddTestWithExistingQuestions(ExistingQuestionTestBLL test);
    }
}