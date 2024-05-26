using System.ComponentModel.DataAnnotations;

namespace ST10134934_CLDV6211_Part_Two.Models
{
    public class TransactionHistory
    {
        [Key] public int TransactionHistoryId { get; set; } 
              public int TransactionId { get; set; }
              public DateTime ChangeDate { get; set; }


              public Transaction? Transaction { get; set; }

    }



}
