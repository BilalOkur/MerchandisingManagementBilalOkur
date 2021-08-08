using MerchandisingManagementCore;
using MerchandisingManagementDataAccess.Interfaces;
using MerchandisingManagementDTOs.CompoundDTO;
using MerchandisingManagementDTOs.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MerchandisingManagementDataAccess
{
    public class ProductDataAccess : RepositoryBase<Product>, IProductDataAccess
    {
        private readonly MerchandisingManagementDataContext _dbContext;
        public ProductDataAccess(MerchandisingManagementDataContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        //special Methods about product

        public List<ProductSearchResult> SearchLiveProduct(string keyword)
        {
            var searchResults = _dbContext.Set<ProductSearchResult>().FromSqlRaw("dbo.SearchProduct @SearchKeyword = {0}", keyword).ToList();
            return searchResults;
        }
        
    }
}
