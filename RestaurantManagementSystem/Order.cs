using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem
{
    public class Order
    {
        public int tableNo { get; set; }
        public string itemType { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public DateTime date { get; set; }
    }
}
