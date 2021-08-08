using MerchandisingManagementCore.Interfaces;
using MerchandisingManagementDTOs.CompoundDTO;
using MerchandisingManagementDTOs.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisingManagementDataAccess.Interfaces
{
    public interface IProductDataAccess : IRepositoryBase<Product>
    {
        //special Methods about product
        public List<ProductSearchResult> SearchLiveProduct(string keyword); 

    }
}
