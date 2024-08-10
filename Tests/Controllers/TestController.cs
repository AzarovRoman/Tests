using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.Models;
using Tests.BLL.Services;

namespace Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        private readonly IMapper _mapper;

        public TestController(ITestService testService, IMapper mapper) 
        { 
            _testService = testService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create-test")]
        public ActionResult AddTest(TestModel test)
        {
            _testService.AddTest(test);
            return Ok(test);
        }

        [HttpPost]
        [Route("create-test-with-id")]
        public ActionResult<int> AddTestWithExistingQuestions(ExistingQuestionTest test)
        {
            int savedId = _testService.AddTestWithExistingQuestions(_mapper.Map<ExistingQuestionTestBLL>(test));

            return Ok(savedId);
        }

        [HttpGet]
        [Route("get-random-test")]
        public ActionResult<TestModel> GetRandomTest()
        {
            return Ok(_testService.GetRandomTest());
        }
    }
}
