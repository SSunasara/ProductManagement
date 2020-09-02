using AutoMapper;
using ProductManagement.Data.Database;
using ProductManagement.DataAccess.Repository.Interface;
using ProductManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.Repository
{
    public class ProductDataRepository : IProductDataRepository
    {
        private IMapper mapper;
        public ProductDataRepository()
        {
            AutomapperHelper automapperHelper = new AutomapperHelper();
            mapper = automapperHelper.mapper;
        }

        public bool Create(ProductViewModel product)
        {
            using (PMDBEntities db = new PMDBEntities())
            {
                Product product1 = mapper.Map<Product>(product);      
                db.Products.Add(product1);
                try
                {
                    if (db.SaveChanges() > 0)
                        return true;
                    return false;
                }
                catch
                {
                    throw;
                }
                
            }
        }
        public bool Delete(int id)
        {
            using (PMDBEntities db = new PMDBEntities())
            {
                db.Products.Remove(db.Products.FirstOrDefault(p => p.id == id));
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public bool Edit(ProductViewModel product)
        {
            using (PMDBEntities db = new PMDBEntities())
            {
                Product product1 = mapper.Map<Product>(product);
                db.Entry(product1).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
        }

        public List<ProductViewModel> GetAllProduct()
        {
            using (PMDBEntities db = new PMDBEntities())
            {
                return mapper.Map < List<ProductViewModel>>(db.Products.ToList());
            }
        }

        public ProductViewModel GetById(int id)
        {
            using (PMDBEntities db = new PMDBEntities())
            {
                return mapper.Map<ProductViewModel>(db.Products.FirstOrDefault(p => p.id == id));
            }
        }

        public List<ProductCategoryViewModel> GetAllCategory()
        {
            using (PMDBEntities db = new PMDBEntities())
            {
                return mapper.Map<List<ProductCategoryViewModel>>(db.ProductCategories.ToList());
            }
        }
    }
}
