using ContactAPI.Infrastructure;
using ContactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPI.Services
{
    public class ContactService : IContactService
    {
        public ContactDTO GetContactById(int id)
        {
            return new ContactDTO() {Id=id,FirstName="Emre",LastName="Büyüktaş" };
        }
    }
}
