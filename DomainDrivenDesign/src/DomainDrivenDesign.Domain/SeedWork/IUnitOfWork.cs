﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
    }
}
