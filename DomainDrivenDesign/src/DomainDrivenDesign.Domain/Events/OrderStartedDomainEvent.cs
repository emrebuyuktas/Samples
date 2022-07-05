using DomainDrivenDesign.Domain.AggregateModels.OrderModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Events
{
    public class OrderStartedDomainEvent: INotification
    {
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
        public Order Order { get; set; }

        public OrderStartedDomainEvent(string buyerFirstName, string buyerLastName, Order order)
        {
            BuyerFirstName = buyerFirstName;
            BuyerLastName = buyerLastName;
            Order = order;
        }
    }
}
