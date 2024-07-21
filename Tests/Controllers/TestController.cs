using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.DAL.Entities;
using Tests.Models;

namespace Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITestService _testService;

        public TestController(ITestService testService) 
        { 
            _testService = testService;
        }
        [HttpPost]
        [Route("create-test")]
        public ActionResult AddTest(TestAPIModel test)
        {
            var testModel = _mapper.Map<TestModel>(test);
            _testService.AddTest(testModel);
            return Ok(test);
        }
    }
}
