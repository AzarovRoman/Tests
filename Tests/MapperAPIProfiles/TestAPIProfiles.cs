using AutoMapper;
using Tests.BLL.Models;
using Tests.Models;

namespace Tests.MapperAPIProfiles
{
    public class TestAPIProfiles : Profile
    {
        public TestAPIProfiles()
        {
            CreateMap<ExistingQuestionTest, ExistingQuestionTestBLL>().ReverseMap();
                //.ForMember(
                //dest => dest.QuestionsId,
                //opt => opt.MapFrom(src => src.Questions.Select(q => q.Id).ToList()));
        }
    }
}
