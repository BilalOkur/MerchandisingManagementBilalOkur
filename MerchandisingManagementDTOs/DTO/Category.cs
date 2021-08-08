using MerchandisingManagementCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MerchandisingManagementDTOs.DTO
{
    public class Category : IEntity
    {
        [Key]
        public string CategoryID { get; set; }
        public string CatergoryName { get; set; }
        public int MinimumStockQuantity { get; set; }       
        public DateTime? EntryDate { get; set; }
    }
}
