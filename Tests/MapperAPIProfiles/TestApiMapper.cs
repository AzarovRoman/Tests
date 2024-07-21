using AutoMapper;
using Tests.BLL.Models;
using Tests.Models;

namespace Tests.MapperAPIProfiles
{
    public class TestAPIMapper : Profile
    {
        public TestAPIMapper()
        {
            CreateMap<TestAPIModel, TestModel>().ReverseMap();
        }
    }
}
