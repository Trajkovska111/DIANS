using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace AtmLocator.Models
{
    public class AtmsContext : DbContext
    {
        public DbSet<Atm> Atms { get; set; }
        public AtmsContext() : base("DefaultConnectionATM2")
        {

        }
        public static AtmsContext Create()
        {
            return new AtmsContext();
        }
    }
}