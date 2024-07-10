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
    }
}
