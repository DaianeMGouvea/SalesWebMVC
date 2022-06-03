using SalesWebMVC.Models.NovaPasta;

namespace SalesWebMVC.Models
{
    public class SallesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SallesStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SallesRecord()
        {
        }

        public SallesRecord(int id, DateTime date, double amount, SallesStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
