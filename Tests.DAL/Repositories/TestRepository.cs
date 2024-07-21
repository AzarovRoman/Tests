using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void AddTest(Test test)
        {
            _context.Add(test);
            _context.SaveChanges();
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
