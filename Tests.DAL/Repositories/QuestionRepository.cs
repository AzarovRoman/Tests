using Microsoft.EntityFrameworkCore;
using Tests.DAL.Entities;

namespace Tests.DAL.Repositories
{
    public class QuestionRepository
    {
        private Context _context;

        public QuestionRepository(Context context)
        {
            _context = context;
        }

        public Question GetQuestionById(int id)
        {
            return _context.Questions.FirstOrDefault(q => q.Id == id);
        }
    }
}