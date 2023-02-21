using CampaignManager.Infrastructure.Models.DBModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CampaignManager.Data.Seed
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            //SeedShippingLocation(modelBuilder);
            SeedShippingPartner(modelBuilder);
            SeedUtilities(modelBuilder);
        }
        private static void SeedShippingLocation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingLocations>().HasData(
               new ShippingLocations
               {
                   Id = 1,
                   LocationName = "USA",
                   IsActive = true,
                   CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                   IsDeleted = false,
                   ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
               },
              new ShippingLocations
              {
                  Id = 2,
                  LocationName = "UAE",
                  IsActive = true,
                  CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                  IsDeleted = false,
                  ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
              },
              new ShippingLocations
              {
                  Id = 3,
                  LocationName = "England",
                  IsActive = true,
                  CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                  IsDeleted = false,
                  ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
              });
        }
        private static void SeedShippingPartner(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingPartner>().HasData(
               new ShippingPartner
               {
                   Id = 1,
                   ShippingPartnerName = "DHL",
                   IsActive = true,
                   CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                   IsDeleted = false,
                   ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
               },
              new ShippingPartner
              {
                  Id = 2,
                  ShippingPartnerName  = "FedEx",
                  IsActive = true,
                  CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                  IsDeleted = false,
                  ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
              },
              new ShippingPartner
              {
                  Id = 3,
                  ShippingPartnerName = "UPS",
                  IsActive = true,
                  CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                  IsDeleted = false,
                  ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
              });
        }
        private static void SeedUtilities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Utilities>().HasData(
               new Utilities
               {
                   Id = 1,
                   UtitilityName = "Custom Utility",
                   UtilityDescription="",
                   UtilityIconUrl = "",
                   PhysicalUtility = false,
                   DigitalUtility= false,
                   ExperientialUtility= false,
                   IsActive = true,
                   CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                   IsDeleted = false,
                   ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
               },
              new Utilities
              {
                  Id = 2,
                  UtitilityName = "Merch",
                  UtilityDescription = "",
                  UtilityIconUrl = "",
                  PhysicalUtility = true,
                  DigitalUtility = false,
                  ExperientialUtility = false,
                  IsActive = true,
                  CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                  IsDeleted = false,
                  ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
              },
              new Utilities
              {
                  Id = 3,
                  UtitilityName = "Audio",
                  UtilityDescription = "",
                  UtilityIconUrl = "",
                  PhysicalUtility = false,
                  DigitalUtility = true,
                  ExperientialUtility = false,
                  IsActive = true,
                  CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                  IsDeleted = false,
                  ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
              },
            new Utilities
            {
                Id = 4,
                UtitilityName = "Event",
                UtilityDescription = "",
                UtilityIconUrl = "",
                PhysicalUtility = false,
                DigitalUtility = false,
                ExperientialUtility = true,
                IsActive = true,
                CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                IsDeleted = false,
                ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
            },
             new Utilities
             {
                 Id = 5,
                 UtitilityName = "AMA",
                 UtilityDescription = "",
                 UtilityIconUrl = "",
                 PhysicalUtility = false,
                 DigitalUtility = true,
                 ExperientialUtility = false,
                 IsActive = true,
                 CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                 IsDeleted = false,
                 ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
             },
              new Utilities
              {
                  Id = 6,
                  UtitilityName = "Martaverse Event",
                  UtilityDescription = "",
                  UtilityIconUrl = "",
                  PhysicalUtility = false,
                  DigitalUtility = true,
                  ExperientialUtility = true,
                  IsActive = true,
                  CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                  IsDeleted = false,
                  ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
              },
               new Utilities
               {
                   Id = 7,
                   UtitilityName = "Promocode",
                   UtilityDescription = "",
                   UtilityIconUrl = "",
                   PhysicalUtility = false,
                   DigitalUtility = true,
                   ExperientialUtility = false,
                   IsActive = true,
                   CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                   IsDeleted = false,
                   ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
               },
             new Utilities
             {
                 Id = 8,
                 UtitilityName = "Physical Tickets",
                 UtilityDescription = "",
                 UtilityIconUrl = "",
                 PhysicalUtility = false,
                 DigitalUtility = false,
                 ExperientialUtility = true,
                 IsActive = true,
                 CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                 IsDeleted = false,
                 ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
             }, 
             new Utilities
             {
                 Id = 9,
                 UtitilityName = "Newsletter",
                 UtilityDescription = "",
                 UtilityIconUrl = "",
                 PhysicalUtility = false,
                 DigitalUtility = true,
                 ExperientialUtility = false,
                 IsActive = true,
                 CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                 IsDeleted = false,
                 ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
             },
             new Utilities
             {
                 Id = 10,
                 UtitilityName = "Exclusive Audio",
                 UtilityDescription = "",
                 UtilityIconUrl = "",
                 PhysicalUtility = false,
                 DigitalUtility = true,
                 ExperientialUtility = false,
                 IsActive = true,
                 CreatedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                 IsDeleted = false,
                 ModifiedDate = DateTime.ParseExact("24/02/2023 13:45:00", "dd/MM/yyyy HH:mm:ss", null)
             });
        }
    }
}
