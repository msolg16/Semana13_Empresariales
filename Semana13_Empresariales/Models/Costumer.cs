using System.ComponentModel.DataAnnotations;

namespace Semana13_Empresariales.Models
{
    public class Costumer
    {
        public Costumer()
        {
            Invoices = new List<Invoice>();
        }

        //Primary Key
        public int CostumerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        //Navigation Property
        public virtual ICollection<Invoice> Invoices { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
