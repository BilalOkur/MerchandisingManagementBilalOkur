using MerchandisingManagementDataAccess.Interfaces;
using MerchandisingManagementDTOs.DTO;
using MerchandisingManagementServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MerchandisingManagementServices
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryDataAccess _categoryDataAccess;
        public CategoryManager(ICategoryDataAccess categoryDataAccess)
        {
            _categoryDataAccess = categoryDataAccess;
        }

        public void AddCategory(Category category)
        {
            _categoryDataAccess.Add(category);
        }

        public List<Category> GetAllCategory()
        {
            return _categoryDataAccess.GetAll();
        }

        public List<Category> GetCategoryByName(string categoryName)
        {
            return _categoryDataAccess.GetList(p => p.CatergoryName == categoryName);
        }
    }
}
