﻿using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using System.Collections.Generic;

namespace Winter.Logic
{
    public interface ICategory
    {
        int AddCategory(CategoryInputViewModel model);
        IEnumerable<CategoryOutputViewModel> GetCategory();
        CategoryOutputViewModel GetCategoryById(int? Id);
        bool DeleteCategory(int? Id);
        bool UpdateCategory(CategoryEditViewModel model);
    }
}