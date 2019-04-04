using System;

namespace PastaHouse.Models
{
    public class Order
    {
        public Order()
        {
            IsActive = true;
        }

        public int OrderId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Client Client { get; set; }
        //public virtual { get; set; }
    }
}