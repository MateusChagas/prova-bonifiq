namespace ProvaPub.Models
{
    public class TotalList
    {
        public List<Customer> Customers { get; set; }

        public List<Product> Products { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
    }
}
