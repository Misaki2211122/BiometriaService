using Application.Abstractions.Database;
using Application.Domains.Entities;
using Application.Domains.Requests.Android;
using Application.Domains.Responses.Android;
using MediatR;

namespace Application.Handlers.Android;

public class GetDeviceIdHandler: IRequestHandler<GetDeviceIdRequest, GetDeviceIdResponse>
{
    private readonly IRepository<AndroidEntity> _repositoryAndroidEntity;

    public GetDeviceIdHandler(IRepository<AndroidEntity> repositoryAndroidEntity)
    {
        _repositoryAndroidEntity = repositoryAndroidEntity;
    }

    public async Task<GetDeviceIdResponse> Handle(GetDeviceIdRequest request,
        CancellationToken cancellationToken)
    {
        // отправка запроса об успешной аутентификации на приложени 
        
        var deviceAutorize= _repositoryAndroidEntity
            .Get(x => x.DeviceId == request.DeviceId).FirstOrDefault();

        if (request.DeviceId != null)
            return new GetDeviceIdResponse() {Success = true, TimeAuthorize = deviceAutorize.DateLastAuth};
        else
            return new GetDeviceIdResponse()
                {Success = false, ErrorMessage = "Не удалось получить ответ от ПК! Попробуйте позже.."};
    }
}