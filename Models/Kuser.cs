using System.ComponentModel.DataAnnotations;

namespace ST10134934_CLDV6211_Part_Two.Models
{
    public class Kuser
    {
        public enum UserType
        {
            Customer,
            Artisan
        }

        [Key] public int KuserId { get; set; }
        public string? KuserName { get; set; }
        public string? KuserEmail { get; set; }
        public UserType KuserType { get; set; }


        //Navigate to transactions (the bridge)
        public List<Transaction>? Transactions { get; set; }

    }



}
