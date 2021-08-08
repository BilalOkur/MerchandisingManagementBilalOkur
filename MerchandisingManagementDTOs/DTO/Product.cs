using MerchandisingManagementCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MerchandisingManagementDTOs.DTO
{
    public class Product : IEntity
    {
        [Key]
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int StockQuantity { get; set; }
    }
}
