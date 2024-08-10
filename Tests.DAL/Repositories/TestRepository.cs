using Microsoft.EntityFrameworkCore;
using Tests.DAL.Entities;
using Tests.DAL.Interfaces;

namespace Tests.DAL.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly Context _context;

        public TestRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод добавлет тест в базу данных
        /// </summary>        
        public int AddTest(Test test)
        {
            _context.Tests.Add(test);
            _context.SaveChanges();

            return test.Id;
        }

        public int AddTestWithExistingQuestion(Test test)
        {
            test.Questions.ForEach(q => _context.Questions.Entry(q).State = EntityState.Unchanged);

            _context.Tests.Add(test);
            _context.SaveChanges();

            return test.Id;
        }

        public Test GetRandomTest()
        {
            Random random = new Random();
            int skipper = random.Next(0, _context.Tests.Count());
            var test = _context.Tests.Include(x => x.Questions).Skip(skipper).Take(1).FirstOrDefault();
            return test;
        }
        public Test GetTestRandom()
        {
            Random random = new Random();
            int skipper = random.Next(0, _context.Tests.Count());
            var test = _context.Tests.Include(x => x.Questions).ThenInclude(x => x.Answers).Skip(skipper).Take(1).FirstOrDefault();
            return test;
        }
    }
}
