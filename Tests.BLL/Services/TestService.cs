using AutoMapper;
using Tests.BLL.Exceptions;
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

        public TestModel GetRandomTest()
        {
            Test testFromDb = _testRepository.GetRandomTest();

            if (testFromDb is null)
            {
                throw new NotFoundException("Нет ни одного теста");
            }

            TestModel test = _mapper.Map<TestModel>(testFromDb);

            return test;
        }
    }
}
