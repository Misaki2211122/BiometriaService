namespace Application.Domains.Entities;

public class AndroidEntity: BaseEntity
{
    public string DeviceId { get; set; }
    
    public DateTime DateLastAuth { get; set; }
}