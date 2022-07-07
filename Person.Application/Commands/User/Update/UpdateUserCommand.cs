using MediatR;
using Person.Application.Base;
using Person.Application.Responses;

namespace Person.Application.Commands.User.Update
{
    public class UpdateUserCommand : EntityDto<int>, IRequest<UserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GenderId { get; set; }
        public string PersonalNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}
