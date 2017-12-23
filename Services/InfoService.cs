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
    public class InfoService : IInfoService
    {
        private ProductContext _context;

        public InfoService(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<ProductInfo>> Get()
        {
            return await _context.ProductInfo.ToListAsync();
        }

        public async Task<List<ProductInfo>> GetByID(long id)
        {
            ProductInfo objectProductInfo = await _context.ProductInfo.FirstOrDefaultAsync(pi => pi.id == id);
            List<ProductInfo> product = new List<ProductInfo>();
            try
            {
                product.Add(objectProductInfo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public async Task Post(ProductInfo item)
        {
            try
            {
                _context.ProductInfo.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Put(long id, ProductInfo item)
        {
            try
            {
                var result = _context.ProductInfo.FirstOrDefault(t => t.id == id);


                if (IsAlphaName(item) && IsNumericID(item))
                {
                    result.id = item.id;
                    result.name = item.name;
                    _context.ProductInfo.Update(result);
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
                var result = _context.ProductInfo.FirstOrDefault(t => t.id == id);
                _context.ProductInfo.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        bool IsAlphaName(ProductInfo item)
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

        bool IsNumericID(ProductInfo item)
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