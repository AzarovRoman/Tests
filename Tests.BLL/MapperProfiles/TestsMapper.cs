using AutoMapper;
using Tests.BLL.Models;
using Tests.DAL.Entities;

namespace Tests.BLL.MapperProfiles
{
    public class TestsMapper : Profile
    {
        public TestsMapper() 
        { 
            CreateMap<TestModel, Test>().ReverseMap();
        }
    }
}
