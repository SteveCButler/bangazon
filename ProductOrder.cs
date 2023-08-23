using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace bangazon;

public class ProductOrder
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; } 
}
