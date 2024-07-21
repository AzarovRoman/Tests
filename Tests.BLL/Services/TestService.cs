using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.BLL.Validations;
using Tests.DAL.Entities;
using Tests.DAL.Interfaces;

namespace Tests.BLL.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }
        public void AddTest(TestModel test)
        {
            List<QuestionModel> questions = test.Questions;

            foreach (QuestionModel question in questions)
            {
                if (Validation.IsCorrectQuestion(question) == false)
                {
                    throw new Exception("Список ответов не удовлетворяет требования создания вопроса - (1 правильный и 3 неправильных ответа) или текст вопроса отсутсвует");
                }
            }

            //Проверка на наличие минимум 5 вопросов в тесте
            var questionCount = test.Questions.Count();

            if (questionCount < 5)
            {
                throw new Exception($"В тесте должно находиться не менее пяти вопросов, необходимо добавить ещё {5 - questionCount}");
            }

            _testRepository.AddTest(_mapper.Map<Test>(test));
        }
    }
}
