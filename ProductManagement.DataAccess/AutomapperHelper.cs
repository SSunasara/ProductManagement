using AutoMapper;
using ProductManagement.Data.Database;
using ProductManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess
{
    public class AutomapperHelper
    {
        public IMapper mapper;
        public AutomapperHelper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserViewModel, UserDetail>();
                cfg.CreateMap<UserDetail, UserViewModel>();
                cfg.CreateMap<ProductViewModel, Product>();
                cfg.CreateMap<Product, ProductViewModel>().
                ForMember(pvm => pvm.Category, map=>map.MapFrom(p=>p.ProductCategory.Category)).
                ForMember(pvm => pvm.User, map => map.MapFrom(p => p.UserDetail.Name));
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
            });

            mapper = config.CreateMapper();
        }
    }
}
