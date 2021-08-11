using MerchandisingManagementDataAccess.Interfaces;
using MerchandisingManagementDTOs.CompoundDTO;
using MerchandisingManagementDTOs.DTO;
using MerchandisingManagementServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisingManagementServices
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDataAccess _productDataAccess;
        private readonly ICategoryManager _categoryManager;
        public ProductManager(IProductDataAccess productDataAccess, ICategoryManager categoryManager)
        {
            _productDataAccess = productDataAccess;
            _categoryManager = categoryManager;
        }

        public List<ProductSearchResult> SearchProduct(string keyword) 
        {
            return _productDataAccess.SearchLiveProduct(keyword);
        }

        public AddProductResponse AddProduct(Product product) 
        {
            if (string.IsNullOrEmpty(product.Title))
            {
                return new AddProductResponse() { IsSucceed = false, WarningMessage = "Product Title can not be empty" };
            }
            else if (product.Title.Length > 200) 
            {
                return new AddProductResponse() { IsSucceed = false, WarningMessage = "Product Title character can not more than 200" };
            }
            if (string.IsNullOrEmpty(product.CategoryName))
            {
                return new AddProductResponse() { IsSucceed = false, WarningMessage = "CategoryName can not be empty" };
            }

            // Check category Exist
            var categoryList =_categoryManager.GetCategoryByName(product.CategoryName);
            if (categoryList.Count == 0)
            {
                return new AddProductResponse() { IsSucceed = false, WarningMessage = "CategoryName can not be found" };
            }

            _productDataAccess.Add(product);
            return new AddProductResponse() { IsSucceed = true, WarningMessage = string.Empty };
        }
    }
}
