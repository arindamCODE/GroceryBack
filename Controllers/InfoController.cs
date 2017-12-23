using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace GroceryBack.Controllers
{
    [Route("api/[controller]")]
    public class InfoController : Controller
    {
        private IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }


        [HttpGet]
        public Task<List<ProductInfo>> GetAll()
        {
            return _infoService.Get();
        }


        [HttpGet("{id}")]
        public Task<List<ProductInfo>> GetID(long id)
        {
            return _infoService.GetByID(id);
        }


        [HttpPost]
        public void Create([FromBody] ProductInfo item)
        {

            _infoService.Post(item);
        }

        [HttpPut("{id}")]

        public void Update(long id, [FromBody] ProductInfo item)
        {
            _infoService.Put(id, item);
        }

        [HttpDelete("{id}")]
        public void Remove(long id)
        {
            _infoService.Delete(id);
        }

    }
}
