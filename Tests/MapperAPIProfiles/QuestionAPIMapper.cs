using AutoMapper;
using Tests.BLL.Models;
using Tests.Models;

namespace Tests.MapperAPIProfiles
{
    public class QuestionAPIMapper : Profile
    {
        public QuestionAPIMapper() 
        {
            CreateMap<QuestionAPIModel, QuestionModel>().ReverseMap();
            CreateMap<AnswerAPIModel, AnswerModel>().ReverseMap();
        }
    }
}
