using Person.Core.Entities;
using Person.Core.Repositories;
using Person.Infastructure.Data;
using Person.Infastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Infastructure.Repositories
{
    public class UserRepository: Repository<User>,IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
