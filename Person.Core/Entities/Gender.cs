using Person.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Core.Entities
{
    public class Gender  : Entity<int>
    {
        public string Name { get; set; }
    }
}
