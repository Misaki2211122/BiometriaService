using Application.Abstractions.Database;
using Application.Domains.Entities;
using Application.Domains.Requests.Android;
using Application.Domains.Responses.Android;
using MediatR;

namespace Application.Handlers.Android;

public class DeviceIdAuthorizeHandler: IRequestHandler<DeviceIdAuthorizeRequest, DeviceIdAuthorizeResponse>
{
    private readonly IRepository<AndroidEntity> _repositoryAndroidEntity;

    public DeviceIdAuthorizeHandler(IRepository<AndroidEntity> repositoryAndroidEntity)
    {
        _repositoryAndroidEntity = repositoryAndroidEntity;
    }

    public async Task<DeviceIdAuthorizeResponse> Handle(DeviceIdAuthorizeRequest request,
        CancellationToken cancellationToken)
    {
        var deviceAutorize= _repositoryAndroidEntity
            .Get(x => x.DeviceId == request.DeviceId).FirstOrDefault();
  
        deviceAutorize.DateLastAuth = DateTime.Now;

        _repositoryAndroidEntity.Update(deviceAutorize);

        if (request.DeviceId != null)
            return new DeviceIdAuthorizeResponse() {Success = true};
        else
            return new DeviceIdAuthorizeResponse()
                {Success = false, ErrorMessage = "Не удалось получить ответ от ПК! Попробуйте позже.."};
    }
}