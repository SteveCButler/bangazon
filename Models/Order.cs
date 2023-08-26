
using System.Security.Cryptography.X509Certificates;

namespace bangazon.Models;

public class Order
{
    public Order() { 
        this.Products = new HashSet<Product>();
    }
    public int Id { get; set; }
    
    public int UserId { get; set; }
    public int StatusId { get; set; }
    //public string OrderStatus { get; set; }

    public DateTime OrderDate { get; set; }

    public int User_PaymentId { get; set; }

    public ICollection<Product> Products { get; set; }

   
}
