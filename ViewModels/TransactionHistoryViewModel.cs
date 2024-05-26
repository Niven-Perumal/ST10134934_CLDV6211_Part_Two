using ST10134934_CLDV6211_Part_Two.Models;


namespace ST10134934_CLDV6211_Part_Two.ViewModels
{

    public class TransactionHistoryViewModel
    {
        public List<Transaction>? Transactions { get; set; }

     

        public int? FilterArtId { get; set; }

        public int? FilterKuserId { get; set; }


        public DateTime? FilterOrderDate { get; set; }

        public DateTime? FilterDeliveryDate { get; set; }

       

    }



}
