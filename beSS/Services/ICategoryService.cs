using System;
using System.Collections.Generic;
using beSS.Models;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;

namespace beSS.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategory();
        Category CreateCategory(CreateCategory request);
        Category EditCategory(EditCategory request);
        MessageResponse DeleteCategory(Guid id);
    }
}