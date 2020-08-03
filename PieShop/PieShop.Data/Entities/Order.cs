using System;
using System.Collections.Generic;
using System.Text;

namespace Ingenico.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int TotalPies { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

    }
}
