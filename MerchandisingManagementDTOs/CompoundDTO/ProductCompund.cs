using MerchandisingManagementDTOs.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisingManagementDTOs.CompoundDTO
{
    public class ProductCompund
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int StockQuantity { get; set; }
        public Category Category { get; set; }
    }
}
