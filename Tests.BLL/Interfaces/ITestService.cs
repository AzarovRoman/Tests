using Tests.BLL.Models;

namespace Tests.BLL.Interfaces
{
    public interface ITestService
    {
        /// <summary>
        /// Метод добавляет тест в базу данных
        /// </summary>        
        void AddTest(TestModel test);
    }
}