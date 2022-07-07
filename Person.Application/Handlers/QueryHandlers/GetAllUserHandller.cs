using MediatR;
using Person.Application.Base;
using Person.Application.Commands.User.Queries;
using Person.Application.Mapper;
using Person.Application.Responses;
using Person.Core.Entities;
using Person.Core.Repositories;

namespace Person.Application.Handlers.QueryHandlers
{
    public class GetAllUserHandller : IRequestHandler<UserQueryFilter, List<UserResponse>>
    {
        private readonly IUserRepository _userRepo;
        public GetAllUserHandller(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<List<UserResponse>> Handle(UserQueryFilter request, CancellationToken cancellationToken)
        {
            IQueryable<User> query;
            query = _userRepo.GetAll().WhereIf(!String.IsNullOrEmpty(request.FirstName), x => x.FirstName.Contains(request.FirstName))
                                      .WhereIf(!String.IsNullOrEmpty(request.LastName), x => x.LastName.Contains(request.LastName))
                                       .WhereIf(!String.IsNullOrEmpty(request.PersonalNumber), x => x.PersonalNumber == request.PersonalNumber);
            return ObjectMapper.Mapper.Map<List<UserResponse>>(query);
        }
    }
}
