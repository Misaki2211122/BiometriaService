using Application.Domains.Responses.Android;
using MediatR;

namespace Application.Domains.Requests.Android;

public class DeviceIdAuthorizeRequest: IRequest<DeviceIdAuthorizeResponse>
{
    public string DeviceId { get; set; }
}