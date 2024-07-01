using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.DAL.Entities;
using Tests.DAL.Enums;

namespace Tests.BLL.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public DifficultyEnum Difficulty { get; set; }
        public string Text { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
