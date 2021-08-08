using MerchandisingManagementDTOs.CompoundDTO;
using MerchandisingManagementDTOs.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisingManagementDataAccess
{
    public class MerchandisingManagementDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=MerchandisingManagement;Trusted_Connection=True");
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductSearchResult> ProductSearchResults { get; set; }
        
    }
}
