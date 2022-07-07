using Person.Core.Entities;
using Person.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
