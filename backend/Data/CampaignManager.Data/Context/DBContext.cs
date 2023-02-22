using CampaignManager.Data.Seed;
using CampaignManager.Infrastructure.Models.DBModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static CampaignManager.Infrastructure.Common.Enums.CampaignManagerEnums;

namespace CampaignManager.Data.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<ShippingLocations> ShippingLocations { get; set; }
        public virtual DbSet<ShippingPartner> ShippingPartners { get; set; }
        public virtual DbSet<Utilities> Utilities { get; set; }
        public virtual DbSet<Campaigns> Campaigns { get; set; }
        public virtual DbSet<CampaignUtilities> CampaignUtilities { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ClaimUtility> ClaimUtilities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedData();
        }
    }
}
