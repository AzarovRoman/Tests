using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DAL.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public List<Question> Questions { get; set; }
        public string Name { get; set; }

    }
}
