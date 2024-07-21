using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.DAL.Entities;
using Tests.DAL.Interfaces;
using Tests.DAL.Repositories;

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
            _testRepository.AddTest(_mapper.Map<Test>(test));

        }
        public TestModel GetTestRandom()
        {
            var test = _testRepository.GetTestRandom();
            var testModel = _mapper.Map<TestModel>(test);

            if (testModel != null)
            {
                return testModel;
            }
            else
            {
                throw new Exception("Теста в базе данных не существует, повторите попытку");
            }
        }
    }
}
