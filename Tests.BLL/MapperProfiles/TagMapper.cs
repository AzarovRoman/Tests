using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.BLL.Models;
using Tests.DAL.Entities;

namespace Tests.BLL.MapperProfiles
{
    public class TagMapper : Profile
    {
        public TagMapper() 
        {
            CreateMap<TagModel, Tag>().ReverseMap(); 
        }
    }
}
