﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain
{
	public class EntityBase
	{
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }

        public EntityBase() 
        { 
            CreationDate = DateTime.Now;

        }
	}
}
