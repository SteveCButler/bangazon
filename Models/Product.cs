using System.ComponentModel.DataAnnotations;
namespace bangazon.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public int SellerId { get; set; }
    public int ProductTypeId { get; set; }

    List<Order> orders { get; set; }

}
