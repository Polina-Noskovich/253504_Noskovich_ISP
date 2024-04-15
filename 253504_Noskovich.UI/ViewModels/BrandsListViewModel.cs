using _253504_Noskovich.Application.BrandUseCases.Queries;
using _253504_Noskovich.Application.ProductUseCases.Queries;
using _253504_Noskovich.Application.ProductUseCases.Commands;
using _253504_Noskovich.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using _253504_Noskovich.Domain.Entities;

namespace _253504_Noskovich.UI.ViewModels;

public partial class BrandsListViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public BrandsListViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }
    public ObservableCollection<Brand> Brands { get; set; } = new();
    public ObservableCollection<Product> Products { get; set; } = new();

    //Выбранный в списке курс
    [ObservableProperty]
    Brand selectedBrand;

    //Команда обновления списка курсов
    [RelayCommand]
    async Task UpdateBrandsList() => await GetBrands();

    [RelayCommand]
    async Task UpdateProductsList() => await GetProducts();

    [RelayCommand]
    async Task ShowDetails(Product product) => await GotoDetailsPage(product);

    [RelayCommand]
    async Task AddBrandPage() => await GoToAddBrandPage();

    [RelayCommand]
    async Task AddProductPage() => await GoToAddProductPage();

    private async Task GoToAddBrandPage()
    {
        await Shell.Current.GoToAsync(nameof(AddBrand));
    }
    private async Task GoToAddProductPage()
    {
        await Shell.Current.GoToAsync(nameof(AddProduct));
    }
    private async Task GotoDetailsPage(Product product)
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"product", product}
        };
        await Shell.Current.GoToAsync(nameof(ProductDetails), parameters);
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
    public async Task GetProducts()
    {
        var products = await _mediator.Send(new GetProductsByBrandQuery(selectedBrand.Id));
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        });
    }
}
