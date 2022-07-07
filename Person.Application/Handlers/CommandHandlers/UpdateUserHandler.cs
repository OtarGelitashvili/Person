using MediatR;
using Person.Application.Commands.User.Update;
using Person.Application.Mapper;
using Person.Application.Responses;
using Person.Core.Repositories;

namespace Person.Application.Handlers.CommandHandlers
{
    internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepo;
        public UpdateUserHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepo.GetByIdAsync(request.Id);
            if (user.Result == null)
            {
                throw new ApplicationException("User not found");
            }
            ObjectMapper.Mapper.Map(request, user.Result);
            await _userRepo.UpdateAsync(user.Result);
            var userRespponse = ObjectMapper.Mapper.Map<UserResponse>(request);
            return userRespponse;
        }
    }
}
