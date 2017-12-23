using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface IInfoService
    {
        Task<List<ProductInfo>> Get();
        Task<List<ProductInfo>> GetByID(long id);
        Task Post(ProductInfo item);
        Task Put(long id, ProductInfo item);
        Task Delete(long id);
    }
}