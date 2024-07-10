using Tests.DAL.Entities;

namespace Tests.DAL.Interfaces
{
    public interface ITestRepository
    {
        /// <summary>
        /// Метод добавляет тест в базу данных
        /// </summary>        
        void AddTest(Test test);
    }
}