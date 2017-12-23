using System;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Services
{
    public class GroupService : IGroupService
    {
        private ProductContext _context;

        public GroupService(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<ProductGroup>> Get()
        {
            return await _context.ProductGroup.ToListAsync();
        }

        public async Task<List<ProductGroup>> GetByID(long id)
        {
            ProductGroup objectProductGroup = await _context.ProductGroup.FirstOrDefaultAsync(pi => pi.id == id);
            List<ProductGroup> product = new List<ProductGroup>();
            try
            {
                product.Add(objectProductGroup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public async Task Post(ProductGroup item)
        {
            try
            {
                _context.ProductGroup.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Put(long id, ProductGroup item)
        {
            try
            {
                var result = _context.ProductGroup.FirstOrDefault(t => t.id == id);


                if (IsAlphaName(item) && IsNumericID(item))
                {
                    result.id = item.id;
                    result.name = item.name;
                    _context.ProductGroup.Update(result);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                var result = _context.ProductGroup.FirstOrDefault(t => t.id == id);
                _context.ProductGroup.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        bool IsAlphaName(ProductGroup item)
        {
            string pattern = "^[A-Za-z ]+$";
            try
            {
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(item.name) == false)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        bool IsNumericID(ProductGroup item)
        {
            string pattern = "^[0-9 ]+$";
            string str = item.id.ToString();
            try
            {
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(str) == false)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}