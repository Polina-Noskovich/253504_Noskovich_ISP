using _253504_Noskovich.Application.ProductUseCases.Queries;
using _253504_Noskovich.Application.BrandUseCases.Queries;
using _253504_Noskovich.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Noskovich.UI.ViewModels
{
    [QueryProperty(nameof(Product), "product")]
    public partial class EditProductViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public EditProductViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<Brand> Brands { get; set; } = new();

        [ObservableProperty]
        Product product;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        decimal cost;

        [ObservableProperty]
        double volume;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        DateTime createdAt;

        [ObservableProperty]
        string imagePath;

        [ObservableProperty]
        int? brandId;

        [ObservableProperty]
        Brand? selectedBrand;

        [RelayCommand]
        async Task Enter() => await EditProduct();

        [RelayCommand]
        async Task SelectFile() => await SelectImage();

        [RelayCommand]
        async Task UpdateBrandsList() => await GetBrands();

        private async Task EditProduct()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(ImagePath) || SelectedBrand == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Вы не заполнили все поля", "Ок");
                return;
            }
            await _mediator.Send(new EditProductQuery(Product.Id, Name.Trim(), CreatedAt, Description, Cost, Volume, ImagePath, SelectedBrand.Id));
            await Shell.Current.GoToAsync(nameof(BrandsList));
        }
        private async Task SelectImage()
        {
            var images = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Pick Barcode/QR Code Image",
                FileTypes = FilePickerFileType.Images
            });
            ImagePath = images.FullPath.ToString();
        }
        private async Task GetBrands()
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Brands.Clear();
                foreach (var brand in brands)
                {
                    Brands.Add(brand);
                }
            });
            Name = Product.Name;
            Cost = Product.Cost;
            Volume = Product.Volume;
            Description = Product.Description;
            CreatedAt = Product.CreatedAt;
            ImagePath = Product.ImagePath;
            BrandId = Product.BrandId;

            foreach (var item in Brands)
            {
                if (item.Id == BrandId)
                {
                    SelectedBrand = item;
                }
            }
        }

    }
}
