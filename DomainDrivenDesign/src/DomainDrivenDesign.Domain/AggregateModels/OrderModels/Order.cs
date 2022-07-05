using DomainDrivenDesign.Domain.Events;
using DomainDrivenDesign.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.AggregateModels.OrderModels
{
    public class Order:BaseEntity,IAggregateRoot
    {
        public DateTime OrderDate { get; private set; }
        public string Description { get; private set; }
        public Address Address { get; private set; }
        public int BuyerId { get; private set; }
        public string OrderStatus { get; private set; }
        public ICollection<OrderItem> OrderItems { get; private set; }

        public Order(DateTime orderDate, string description, Address address, int buyerId, string orderStatus, 
            ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now)
                throw new Exception("Order date can not be smaller than current date");
            if (String.IsNullOrEmpty(address.Country))
                throw new Exception("City can not be empty");
            OrderDate = orderDate;
            Description = description;
            Address = address;
            BuyerId = buyerId;
            OrderStatus = orderStatus;
            OrderItems = orderItems;
            AddDomainEvents(new OrderStartedDomainEvent("","",this));
        }
        public void AddOrderItem(int quantity,decimal price,int productId)
        {
            OrderItem item=new OrderItem(quantity,price,productId);
            OrderItems.Add(item);
        }
    }
}
