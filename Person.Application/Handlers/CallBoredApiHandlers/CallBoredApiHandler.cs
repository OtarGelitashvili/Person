using MediatR;
using Newtonsoft.Json;
using Person.Application.Commands;
using Person.Application.Responses;

namespace Person.Application.Handlers.CallApiHandlers
{
    public class CallBoredApiHandler : IRequestHandler<CallBoredApiCommad, CallBoredApiResponse>
    {

        public CallBoredApiHandler()
        {

        }
        public async Task<CallBoredApiResponse> Handle(CallBoredApiCommad request, CancellationToken cancellationToken)
        {
            var url = $"http://www.boredapi.com/api/activity";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CallBoredApiResponse>(jsonString);
                }
            }
            return new CallBoredApiResponse();
        }
    }
}
