using MediatR;
using Person.Application.Responses;

namespace Person.Application.Commands.User.Queries
{
    public class UserQueryFilter : IRequest<List<UserResponse>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalNumber { get; set; }
    }
}
