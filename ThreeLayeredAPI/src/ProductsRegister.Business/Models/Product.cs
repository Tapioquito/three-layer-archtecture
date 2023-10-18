namespace ProductsRegister.Business.Models
{
    public class Product : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool isActive { get; set; }
    }
}
