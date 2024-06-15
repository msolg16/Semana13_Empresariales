namespace Semana13_Empresariales.Models
{
    public class Detail
    {
        //primary key
        public int DetailId { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float Subtotal { get; set; }

        //foreign key
        public int IdInvoices { get; set; }
        public virtual Invoice Invoice { get; set; }
        public int IdProduct { get; set; }
        public virtual Product Product { get; set; }

    }
}
