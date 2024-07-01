using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tests.BLL.Models;
using Tests.BLL.Services;
using Tests.DAL;

namespace Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly QuestionService _questionService;
        public QuestionController(Context ctx, IMapper mapper) 
        {
            _questionService = new(ctx, mapper);
        }

        [HttpPost]
        [Route("create-question")]
        public ActionResult<int> AddQuestion(QuestionModel question)
        {
            return Ok(_questionService.AddQuestion(question));
        }
    }
}
