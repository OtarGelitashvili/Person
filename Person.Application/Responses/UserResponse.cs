using Person.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Responses
{
    public class UserResponse : EntityDto<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; }
       // public Gender Gender { get; set; }
    }
}
