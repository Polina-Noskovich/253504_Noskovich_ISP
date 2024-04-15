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
    public partial class AddProductViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AddProductViewModel(IMediator mediator)
        {
            _mediator = mediator;
            Cost = 20000;
        }
        public ObservableCollection<Brand> Brands { get; set; } = new();

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
        int brandId;

        [ObservableProperty]
        string imagePath;

        [ObservableProperty]
        Brand? selectedBrand;

        [RelayCommand]
        async Task Enter() => await AddProduct();

        [RelayCommand]
        async Task UpdateBrandsList() => await GetBrands();

        [RelayCommand]
        async Task SelectFile() => await SelectImage();
        private async Task AddProduct()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description) || string.IsNullOrEmpty(ImagePath) || SelectedBrand == null)
            {
                await Shell.Current.DisplayAlert("Ошибка", "Вы не заполнили все поля", "Ок");
                return;
            }
            BrandId = SelectedBrand.Id;
            await _mediator.Send(new AddProductQuery(Name.Trim(), CreatedAt, Description, Cost, Volume, ImagePath, BrandId));
            await Shell.Current.GoToAsync(nameof(BrandsList));
        }
        public async Task GetBrands()
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
    }
}
