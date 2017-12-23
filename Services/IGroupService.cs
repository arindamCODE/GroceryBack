using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface IGroupService
    {
        Task<List<ProductGroup>> Get();
        Task<List<ProductGroup>> GetByID(long id);
        Task Post(ProductGroup item);
        Task Put(long id, ProductGroup item);
        Task Delete(long id);
    }
}