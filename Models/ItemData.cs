namespace DrugApp.Models
{
    public class ItemData
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Ownership { get; set; }
    }
    
}