using Person.Application.Base;
using Person.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Person.Application.Commands.User.Create
{
    public class CreateUserCommand : EntityDto<int>, IRequest<UserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}
