namespace Core.Entity;

public interface IEntity
{
    public string Id { get; set; }
    public bool IsDeleted { get; set; }
}