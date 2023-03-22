namespace Core.Entity;

public interface IEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
}