namespace APIBakeryCustomer.Models
{
    public class CustomerDataSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CustomerBakeryCollectionName { get; set; } = null!;
    }
}
