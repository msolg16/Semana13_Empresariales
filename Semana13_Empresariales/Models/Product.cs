namespace Semana13_Empresariales.Models
{
    public class Product
    {
        public Product()
        {
            Details = new List<Detail>();
        }
        //primary key 
        public int ProductId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        //Navigation properties
        public virtual ICollection<Detail> Details { get; set; }

    }
}
