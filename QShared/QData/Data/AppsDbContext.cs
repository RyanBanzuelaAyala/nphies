using AG.Infra.Model.Tables;
using Microsoft.EntityFrameworkCore;
using QData.Data.Seed;
using System;
using System.Collections.Generic;
using System.Text;

namespace QData.Data
{
    public class AppsDbContext : DbContext
    {
        public AppsDbContext(DbContextOptions<AppsDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<DepartmentMappingDetail> DepartmentMappingDetails { get; set; }
        public virtual DbSet<DepartmentMappingProfile> DepartmentMappingProfiles { get; set; }
        public virtual DbSet<InsuranceAccount> InsuranceAccounts { get; set; }
        public virtual DbSet<InsuranceServiceMaster> InsuranceServiceMasters { get; set; }
        public virtual DbSet<BUPARequestLog> BUPARequestLogs { get; set; }
        public virtual DbSet<BUPAResponseLog> BUPAResponseLogs { get; set; }
        
    }
}
