
namespace bangazon.Models;

public class Order
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    public int StatusId { get; set; }

    public DateTime OrderDate { get; set; }

    public int User_PaymentId { get; set; }

    public List<Product> Products { get; set; }
}
