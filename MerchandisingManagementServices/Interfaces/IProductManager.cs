using MerchandisingManagementDTOs.CompoundDTO;
using MerchandisingManagementDTOs.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisingManagementServices.Interfaces
{
    public interface IProductManager
    {
        List<ProductSearchResult> SearchProduct(string keyword);
        AddProductResponse AddProduct(Product product);

    }
}
