using System.ComponentModel.DataAnnotations;
namespace bangazon.Models;

public class PaymentType
{
    public int Id { get; set; }
    [Required]
    public string PaymentMethod { get; set; }

    public List<User> Users { get; set; }

}