using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtmLocator.Data;
using Microsoft.EntityFrameworkCore;

namespace AtmLocator.Models
{
    public static class DbInitialize
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Atm.Any())
            {
                return;
            }

            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\User5531\\Desktop\\skopje_atm.csv");
            string line = "";

            while ((line = file.ReadLine()) != null)
            {
                if (line == null || line.StartsWith(" "))
                    break;
                string[] parts = line.Split(',');
                long Id = long.Parse(parts[0].ToString());
                Atm atm = new Atm();
                //atm.ID = Id;
                atm.Longitude = Double.Parse(parts[1]);
                atm.Latitude = Double.Parse(parts[2]);
                atm.Name = parts[3];
                atm.Street = parts[4];
                atm.OpenHours = parts[5];
                if (parts[6].ToString().Length != 0)
                    atm.Wheelchair = "Wheelchair";
                else atm.Wheelchair = null;
                if (parts[7].ToString().Length != 0)
                    atm.Drive_Through = "Drive-Through";
                else atm.Drive_Through = null;
                
                context.Atm.Add(atm);

            }
            //_ = context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.atm ON;");
            context.SaveChanges();
        }
    }
}
