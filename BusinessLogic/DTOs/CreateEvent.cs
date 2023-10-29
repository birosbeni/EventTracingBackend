﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTracingBackend.BusinessLogic
{
    public class CreateEvent
    {
        public string Name { get; set; }

        public Guid LocationId { get; set; }

        public int Capacity { get; set; }
    }
}
