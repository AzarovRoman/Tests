using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BLL.MapperProfiles;
using Tests.BLL.Models;
using Tests.DAL;
using Tests.DAL.Entities;
using Tests.DAL.Repositories;

namespace Tests.BLL.Services
{
    public class QuestionService
    {
        private readonly Context _context;
        private readonly QuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public QuestionService(Context ctx, IMapper mapper) 
        {
            _context = ctx;
            _questionRepository = new QuestionRepository(_context);

            _mapper = mapper;
        }

        public int AddQuestion(QuestionModel model)
        {
            var result = _questionRepository.AddQuestion(_mapper.Map<Question>(model));

            if ( result < 1)
            {
                throw new Exception("Не удалось создать новый вопрос для теста");
            }

            return result;
        }
    }
}
