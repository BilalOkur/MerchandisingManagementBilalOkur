using MerchandisingManagementCore;
using MerchandisingManagementDataAccess.Interfaces;
using MerchandisingManagementDTOs.DTO;

namespace MerchandisingManagementDataAccess
{
    public class CategoryDataAccess : RepositoryBase<Category>, ICategoryDataAccess
    {
        private readonly MerchandisingManagementDataContext _dbContext;
        public CategoryDataAccess(MerchandisingManagementDataContext _dbContext) : base(_dbContext)
        {
            _dbContext = new MerchandisingManagementDataContext();
        }
        
        //special Methods about product
    }
}
