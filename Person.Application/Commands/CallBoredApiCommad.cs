using MediatR;
using Person.Application.Responses;

namespace Person.Application.Commands
{
    public class CallBoredApiCommad : IRequest<CallBoredApiResponse>
    {
    }
}
