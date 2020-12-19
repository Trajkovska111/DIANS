﻿namespace AtmLocator.Migrations
{
    using AtmLocator.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AtmLocator.Models.AtmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AtmLocator.Models.AtmsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\User5531\\Downloads\\5th semester\\Dizajn i Arhitektura na Softver\\AtmLocator\\AtmLocator\\skopje_atm.csv");
            string line = "";
            
            while ((line = file.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                long Id = long.Parse(parts[0].ToString());
                Atm atm = new Atm();
                atm.ID = Id;
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
                var existsInDb = context.Atms
                    .Where(c => c.ID == atm.ID)
                    .SingleOrDefault();
                if (existsInDb != null)
                    context.Atms.AddOrUpdate(atm);
                else
                    context.Atms.Add(atm);
            }
        }
    }
}
