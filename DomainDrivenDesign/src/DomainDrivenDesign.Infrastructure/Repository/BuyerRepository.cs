﻿using DomainDrivenDesign.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Repository
{
    public class BuyerRepository : IBuyerRepository
    {
        public Task<int> SaveChangeAsync()
        {
            return Task.FromResult(1);
        }
    }
}
