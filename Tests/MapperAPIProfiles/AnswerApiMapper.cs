using AutoMapper;
using Tests.BLL.Models;
using Tests.Models;

namespace Tests.MapperAPIProfiles
{
    public class AnswerApiMapper : Profile
    {
        public AnswerApiMapper()
        {
            CreateMap<AnswerAPIModel, AnswerModel>().ReverseMap();
        }
    }
}
