using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.BLL.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Список вопросов теста
        /// </summary>
        public List<QuestionModel> Questions { get; set; }
        /// <summary>
        /// Название теста
        /// </summary>
        public string Name { get; set; }

    }
}
