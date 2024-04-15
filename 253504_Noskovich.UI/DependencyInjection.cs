using _253504_Noskovich.UI.Pages;
using _253504_Noskovich.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services
                .AddTransient<BrandsList>()
                .AddTransient<ProductDetails>()
                .AddTransient<AddBrand>()
                .AddTransient<AddProduct>()
                .AddTransient<EditProduct>();


            return services;
        }
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services
                .AddTransient<BrandsListViewModel>()
                .AddTransient<ProductDetailsViewModel>()
                .AddTransient<AddBrandViewModel>()
                .AddTransient<AddProductViewModel>()
                .AddTransient<EditProductViewModel>();
            return services;
        }
    }
}