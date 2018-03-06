﻿using MVC_Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Shop.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["productCategories"] as List<ProductCategory>;

            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory productCategory)
        {
            productCategories.Add(productCategory);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

            if (productToUpdate != null)
            {
                productToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }

        public ProductCategory Find(string id)
        {
            ProductCategory productCategory = productCategories.Find(p => p.Id == id);

            if (productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string id)
        {
            ProductCategory productToRemove = productCategories.Find(p => p.Id == id);

            if (productToRemove != null)
            {
                productCategories.Remove(productToRemove);
            }
            else
            {
                throw new Exception("Product category not found");
            }
        }
    }
}
