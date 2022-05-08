using Application.Domains.Responses.Android;
using MediatR;

namespace Application.Domains.Requests.Android;

public class GetDeviceIdRequest: IRequest<GetDeviceIdResponse>
{
    public string DeviceId { get; set; }
}