﻿using System.Linq;
using System.Collections.Generic;
using ProductCatalog.Core.Contracts;
using ProductCatalog.Infrastructure.Data.Common;
using ProductCatalog.Infrastructure.Data.Model;

namespace ProductCatalog.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            this.repo = _repo;
        }
        public IEnumerable<Product> GetProducts()
        {
            return repo.All<Product>().AsEnumerable();
        }

        public void Save(Product product)
        {
            if (product.Id == 0)
            {
                repo.Add(product);
            }
            else
            {
                repo.Update(product);
            }

            repo.SaveChanges();
        }
    }
}
