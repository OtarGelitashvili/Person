using MediatR;
using Person.Application.Commands.User.Create;
using Person.Application.Mapper;
using Person.Application.Responses;
using Person.Core.Entities;
using Person.Core.Repositories;

namespace Person.Application.Handlers.CommandHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepo;
        public CreateUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = ObjectMapper.Mapper.Map<User>(request);
            if (user is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newUser = await _userRepo.AddAsync(user);
            var UserResponse = ObjectMapper.Mapper.Map<UserResponse>(newUser);
            return UserResponse;
        }
    }
}
