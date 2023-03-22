using Core.Entity;

namespace Entity;

public sealed class Category : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }
    public IList<Product>? Products { get; set; }
}
