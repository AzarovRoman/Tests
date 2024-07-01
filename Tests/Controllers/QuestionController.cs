using Microsoft.AspNetCore.Mvc;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.DAL;

namespace Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(Context ctx, IQuestionService questionService) 
        {
            _questionService = questionService;
        }

        [HttpPost]
        [Route("create-question")]
        public ActionResult<int> AddQuestion(QuestionModel question)
        {
            return Ok(_questionService.AddQuestion(question));
        }

        [HttpGet]
        [Route("get-question/{id}")]
        public ActionResult<QuestionModel> GetQuestionById(int id)
        {
            return Ok(_questionService.GetQuestionById(id));
        }
    }
}
