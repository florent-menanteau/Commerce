using System.ComponentModel.DataAnnotations;

namespace Commerce;

public class ProductModel
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public string Reference { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; } = decimal.Zero;
}

