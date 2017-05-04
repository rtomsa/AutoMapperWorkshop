using AutoMapperWorkshop.Model;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapperWorkshop
{
    public class Order
    {
        private readonly IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();

        public Customer Customer { get; set; }

        public OrderLineItem[] GetOrderLineItems()
        {
            return _orderLineItems.ToArray();
        }

        public void AddOrderLineItem(Product product, int quantity)
        {
            _orderLineItems.Add(new OrderLineItem(product, quantity));
        }

        public IList<OrderLineItem> OrderLineItems { get { return _orderLineItems; } }

<<<<<<< HEAD
    //    public decimal GetTotal()
    //    {
    //        return _orderLineItems.Sum(li => li.GetTotal());
    //    }
=======
        /*public decimal GetTotal()
        {
            return _orderLineItems.Sum(li => li.GetTotal());
        }*/
>>>>>>> c19b5af290189607f7cd1ad6a0efdc3c7540cb78
    }
}
