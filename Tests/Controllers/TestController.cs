using Microsoft.AspNetCore.Mvc;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.BLL.Services;

namespace Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService) 
        { 
            _testService = testService;
        }
        [HttpPost]
        [Route("create-test")]
        public ActionResult AddTest(TestModel test)
        {
            _testService.AddTest(test);
            return Ok(test);
        }
        [HttpGet]
        [Route("get-test-random")]
        public ActionResult GetTestRandom()
        {
            return Ok(_testService.GetTestRandom());
        }
    }
}
