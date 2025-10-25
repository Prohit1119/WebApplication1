namespace PaymentAPI.Models
{
    public class PaymentModel
    {
        public string PaymentType { get; set; }

        public decimal? Amount { get; set; }    

        public string UserName { get; set; }

    }
}
