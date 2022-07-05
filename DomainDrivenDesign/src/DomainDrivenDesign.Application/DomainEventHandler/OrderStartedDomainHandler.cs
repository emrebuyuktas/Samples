using DomainDrivenDesign.Application.Repository;
using DomainDrivenDesign.Domain.AggregateModels.BuyerModels;
using DomainDrivenDesign.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Application.DomainEventHandler
{
    public class OrderStartedDomainHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyerRepository _buyerRepository;

        public OrderStartedDomainHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public Task Handle(OrderStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            if(notification.Order.BuyerId == 0)
            {
                var buyer = new Buyer(notification.BuyerFirstName, notification.BuyerLastName);
                //_buyerRepository.Add(buyer);
            }
            return null;
        }
    }
}
