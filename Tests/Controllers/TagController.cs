using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tests.BLL.Interfaces;
using Tests.BLL.Models;
using Tests.BLL.Services;
using Tests.DAL.Entities;

namespace Tests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;

        public TagController(IMapper mapper, ITagService tagService)
        {
            _mapper = mapper;
            _tagService = tagService;
        }

        [HttpPost]
        [Route("create-tag")]
        public ActionResult AddTag(TagModel model)
        {
            var tagModel = _mapper.Map<TagModel>(model);
            _tagService.AddTag(tagModel);
            return Ok();
        }

        [HttpGet]
        [Route("get-tag/{id}")]
        public ActionResult<TagModel> GetTagById(int id)
        {
            return Ok(_tagService.GetTag(id));
        }

        [HttpDelete]
        [Route("delete-tag/{id}")]
        public ActionResult DeleteTag(int id)
        {
            _tagService.DeleteTag(id);
            return Ok();
        }
    }
}
