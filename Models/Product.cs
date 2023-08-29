using System.ComponentModel.DataAnnotations;
namespace bangazon.Models;

public class Product
{
    public Product()
    {
        this.Orders = new HashSet<Order>();
    }
    public int Id { get; set; }
    [Required]
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public int SellerId { get; set; }
    public int ProductTypeId { get; set; }
    public string ProductTypeName { get; set; }

    public ICollection<Order> Orders { get; set; }
    public List<ProductType> ProductTypes { get; set; }


}
