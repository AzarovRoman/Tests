using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.Models;

namespace Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create-question")]
        public ActionResult<int> AddQuestion(QuestionAPIModel question)
        {
            var questionModel = _mapper.Map<QuestionModel>(question);
            return Ok(_questionService.AddQuestion(questionModel));
        }

        [HttpGet]
        [Route("get-question/{id}")]
        public ActionResult<QuestionModel> GetQuestionById(int id)
        {
            return Ok(_questionService.GetQuestionById(id));
        }

        [HttpGet]
        [Route("get-question-random")]
        public ActionResult<QuestionModel> GetQuestionRandom()
        {
            return Ok(_questionService.GetQuestionRandom());
        }

        [HttpDelete]
        [Route("delete-question/{id}")]
        public ActionResult DeleteQuestion(int id) 
        {
            _questionService.DeleteQuestion(id);

            return Ok();
        }
    }
}
