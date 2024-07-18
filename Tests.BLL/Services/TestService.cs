using AutoMapper;
using Tests.BLL.Exceptions;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.DAL.Entities;
using Tests.DAL.Interfaces;

namespace Tests.BLL.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository testRepository, IQuestionRepository questionRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public void AddTest(TestModel test)
        {
            _testRepository.AddTest(_mapper.Map<Test>(test));
        }

        public int AddTestWithExistingQuestions(ExistingQuestionTestBLL test)
        {
            List<Question> findedQuestions = new List<Question>();

            findedQuestions = _questionRepository.GetQuestionByIds(test.QuestionsId);

            if (findedQuestions.Count == 0 || findedQuestions.Contains(null))
                throw new NotFoundException($"Вопрос в тесте {test.Name} не найден");

            TestModel newTest = new TestModel();
            newTest.Questions = _mapper.Map<List<QuestionModel>>(findedQuestions);
            newTest.Name = test.Name;

            int savedId = _testRepository.AddTestWithExistingQuestion(_mapper.Map<Test>(newTest));

            if (savedId > 0)
                return savedId;
            else
                throw new ServerExeption($"Тест с именем {test.Name} не удалось сохранить");
        }
    }
}
