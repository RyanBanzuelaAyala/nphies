using AG.Infra.Model.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QData.Data.Seed
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Branch>().HasData(
               new Branch { Id = 1, Name = "Jeddah", CreatedAt = DateTime.Now, Deleted = false },
               new Branch { Id = 2, Name = "Riyadh", CreatedAt = DateTime.Now, Deleted = false },
               new Branch { Id = 3, Name = "Madinah", CreatedAt = DateTime.Now, Deleted = false },
               new Branch { Id = 4, Name = "Aseer", CreatedAt = DateTime.Now, Deleted = false },
               new Branch { Id = 5, Name = "Hail", CreatedAt = DateTime.Now, Deleted = false },
               new Branch { Id = 6, Name = "Dammam", CreatedAt = DateTime.Now, Deleted = false },
               new Branch { Id = 7, Name = "Beverly", CreatedAt = DateTime.Now, Deleted = false }
            );

            modelBuilder.Entity<InsuranceServiceMaster>().HasData(
               new InsuranceServiceMaster
               {
                   Id = 1,
                   BaseUrl = "https://test-api.bupa.com.sa/bupa-organization/point/member/reqVerifyMbrPoint",
                   BranchId = 1,
                   Name = "BUPA",
                   UserName = "N/A",
                   Password = "N/A",
                   ProviderCode = "20134",
                   EncryptedProviderID = "XD3cN8+lQgNehTbmSf7LI97P3sqGbu0gfU88kxIBMic=",
                   ClientId = "352d6131c9d92ddd38378548e631495e",
                   ClientSecretId = "c7b0436b3a10bc3817d49578b94f1cc7",
                   CreatedAt = DateTime.Now,
                   Deleted = false
               }
            );

            modelBuilder.Entity<Account>().HasData(
              new Account
              {
                  Id = 1,
                  BranchId = 1,
                  UserName = "sghjeddahapi",
                  Password = "xCEWpu9p1QvaJG89yW70Zw==", //j3dd@h@p!2020
                  SecretKey = "M48OIRffOQiiI13HXSuEX6eNTZKwZ3oLUiKMwjlQWG4=", // AGAPI2020SGHJEDDAHSA01_SK092020
                  CreatedAt = DateTime.Now,
                  Deleted = false
              }
           );


        }
    }
}
