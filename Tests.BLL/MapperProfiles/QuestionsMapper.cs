using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
