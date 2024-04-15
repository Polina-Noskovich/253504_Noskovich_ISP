using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var unitOfWork = services.GetRequiredService<IUnitOfWork>();
            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();
                     
            await unitOfWork.BrandRepository.AddAsync(new Brand(1, "Estee Lauder", "USA", "Care", 1946));
            await unitOfWork.BrandRepository.AddAsync(new Brand(2, "DARLING*", "Italy", "Decorative", 2020));
            await unitOfWork.BrandRepository.AddAsync(new Brand(3, "Rhode Skin", "USA", "Care", 2022));

            await unitOfWork.SaveAllAsync();

            //Resources/Images/Mascara.jpg
            await unitOfWork.ProductRepository.AddAsync(new Product(1, "Сoncealer", new DateTime(2023, 7, 20), "Apply to face", "", 1, 200, 5));
            await unitOfWork.ProductRepository.AddAsync(new Product(2, "Mask", new DateTime(2024, 2, 22), "Apply under eyes", "", 2, 68, 50));
            await unitOfWork.ProductRepository.AddAsync(new Product(3, "Gloss", new DateTime(2024, 1, 11), "Apply to lips", "", 3, 300, 2.8));

            await unitOfWork.ProductRepository.AddAsync(new Product(4, "Mascara", new DateTime(2023, 6, 23), "Apply to eyelashes", "", 1, 340, 7));
            await unitOfWork.ProductRepository.AddAsync(new Product(5, "Serum", new DateTime(2023, 10, 15), "Apply to the neck", "", 2, 22, 8.2));

            await unitOfWork.ProductRepository.AddAsync(new Product(6, "Mascara", new DateTime(2023, 1, 25), "Apply to the neck", "", 2, 34, 8));
            await unitOfWork.ProductRepository.AddAsync(new Product(7, "Mask", new DateTime(2024, 1, 11), "Apply to the neck", "", 3, 6, 5));

            await unitOfWork.SaveAllAsync();
        }
    }
}
