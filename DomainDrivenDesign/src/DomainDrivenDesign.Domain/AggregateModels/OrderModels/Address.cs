using DomainDrivenDesign.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.AggregateModels.OrderModels
{
    public class Address : ValueObject
    {
        public string Country { get; set; }
        public string City { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Country;
        }
    }
}
