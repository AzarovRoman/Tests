using AutoMapper;
using Tests.BLL.Models;
using Tests.DAL.Entities;

namespace Tests.BLL.MapperProfiles
{
    public class QuestionsMapper : Profile
    {
        public QuestionsMapper()
        {
            CreateMap<QuestionModel, Question>().ReverseMap();
            CreateMap<AnswerModel, Answer>().ReverseMap();           
        }
    }
}
