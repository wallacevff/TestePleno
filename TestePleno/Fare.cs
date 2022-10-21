﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePleno.Models
{
    public class Fare : IModel
    {
        public Guid Id { get; set; }
        public Guid OperatorId { get; set; }
        public int Status { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; }
        public Fare()
        {
            this.CreatedAt = DateTime.Now;
        }
    }

      
}
