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
        public AtmsContext() : base("DefaultConnectionATM")
        {

        }
        public static AtmsContext Create()
        {
            return new AtmsContext();
        }
    }
}