namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }


        public int CompanyId { get; set; }

        public Company Company { get; set; }        
    }
}