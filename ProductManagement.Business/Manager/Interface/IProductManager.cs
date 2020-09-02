using ProductManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Manager.Interface
{
    public interface IProductManager
    {
        bool Create(ProductViewModel product);
        List<ProductViewModel> GetAllProduct();
        ProductViewModel GetById(int id);
        bool Edit(ProductViewModel product);
        bool Delete(int id);

        List<ProductCategoryViewModel> GetAllCategory();
    }
}
