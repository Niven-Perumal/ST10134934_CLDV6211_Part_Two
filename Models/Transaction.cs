using System.ComponentModel.DataAnnotations;

namespace ST10134934_CLDV6211_Part_Two.Models
{
    public class Transaction
    {

       [Key] public int TransactionId { get; set; }
             public int? KuserId { get; set; }
             public int? ArtId { get; set; }
             public string? ArtStatus { get; set; }

             public DateTime TransactionDate { get; set; }
             public DateTime ModifiedDate { get; set; }


            //Navigation properties
             public Product? Product { get; set; }
             public Kuser? Kuser { get; set; }
             

    }



}
