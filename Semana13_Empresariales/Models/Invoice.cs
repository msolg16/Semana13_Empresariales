namespace Semana13_Empresariales.Models
{
    public class Invoice
    {
        public Invoice() 
        {
            Details = new List<Detail>();
        }
        //primary key
        public int InvoiceId { get; set; }
        public DateTime DATETIME { get; set; }
        public string InvoiceNumber { get; set; }
        public int Total { get; set; }

        //Foreign key
        public int IdCostumer { get; set; }

        //Navigation properties
        public virtual Costumer Costumer { get; set; }

        public virtual ICollection<Detail> Details { get; set; }

    }
}