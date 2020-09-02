using ProductManagement.Business.Manager.Interface;
using ProductManagement.DataAccess.Repository.Interface;
using ProductManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Manager
{
    public class ProductManager : IProductManager
    {
        IProductDataRepository repository;

        public ProductManager(IProductDataRepository _repository)
        {
            repository = _repository;
        }
        public bool Create(ProductViewModel product)
        {
            return repository.Create(product);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }

        public bool Edit(ProductViewModel product)
        {
            return repository.Edit(product);
        }

        public List<ProductCategoryViewModel> GetAllCategory()
        {
            return repository.GetAllCategory();
        }

        public List<ProductViewModel> GetAllProduct()
        {
            return repository.GetAllProduct();
        }

        public ProductViewModel GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
