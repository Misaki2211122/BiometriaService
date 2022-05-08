namespace Application.Domains;

public class BaseEntity
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Время последного обновления 
    /// </summary>
    public DateTime Updated { get; set; } = DateTime.Now;
}