using System.Collections.Generic;
using FoodDeliveryAppV1.ViewModel;

namespace FoodDeliveryAppV1.ViewModel
{
    public class CustomerOrderViewModel
    {
        public int OrderId { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public string Status { get; set; }
        public string OrderDateTime { get; set; }
        // A collection of items in this order
        public List<CustomerOrderItemViewModel> Items { get; set; }
    }

    public  class CustomerOrderItemViewModel {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
