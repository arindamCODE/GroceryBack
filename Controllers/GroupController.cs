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
    public class GroupController : Controller
    {
        private IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }


        [HttpGet]
        public Task<List<ProductGroup>> GetAll()
        {
            return _groupService.Get();
        }


        [HttpGet("{id}")]
        public Task<List<ProductGroup>> GetID(long id)
        {
            return _groupService.GetByID(id);
        }


        [HttpPost]
        public void Create([FromBody] ProductGroup item)
        {

            _groupService.Post(item);
        }

        [HttpPut("{id}")]

        public void Update(long id, [FromBody] ProductGroup item)
        {
            _groupService.Put(id, item);
        }
   
        [HttpDelete("{id}")]
        public void Remove(long id)
        {
            _groupService.Delete(id);
        }
    
    }
}
