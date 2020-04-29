using System;
namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string Address { get; set; }

        public string ContactPhone { get; set; }


        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
