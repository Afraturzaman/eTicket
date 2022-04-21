﻿using eTicket.Data.Base;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>,IProducerService
    {       
        public ProducerService(AppDbContext context):base(context)
        {
            
        }
        
    }
}
