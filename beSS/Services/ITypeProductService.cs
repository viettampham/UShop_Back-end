using System;
using System.Collections.Generic;
using beSS.Models;
using beSS.Models.ViewModels;

namespace beSS.Services
{
    public interface ITypeProductService
    {
        List<TypeProduct> Get();
        TypeProduct Create(string Name);
        MessageResponse Delete(Guid TypeProductID);
    }
}