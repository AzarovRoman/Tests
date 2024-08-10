using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DAL.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        /// <summary>
        /// Название тега
        /// </summary>
        public string Name { get; set; }
    }
}
