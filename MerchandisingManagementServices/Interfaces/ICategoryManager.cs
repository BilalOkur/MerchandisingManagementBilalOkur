using MerchandisingManagementDTOs.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisingManagementServices.Interfaces
{
    public interface ICategoryManager
    {
        void AddCategory(Category category);
        List<Category> GetCategoryByName(string categoryName);

        List<Category> GetAllCategory();
    }
}
