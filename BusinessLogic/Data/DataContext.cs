﻿using EventTracingBackend.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace EventTracingBackend.BusinessLogic
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Event> EventList { get; set; }
    }
}