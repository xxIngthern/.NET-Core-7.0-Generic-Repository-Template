using Core.Entity;

namespace Entity;

public sealed class Product : IEntity
{
    public string Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public short Quantity { get; set; }

    public string? Country { get; set; }

    public int? Barcode { get; set; }

    public bool IsDeleted { get; set; }

    public Category Category { get; set; } = null!;
}
