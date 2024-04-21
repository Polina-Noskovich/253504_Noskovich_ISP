using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253504_Noskovich.UI.Pages;
using CommunityToolkit.Mvvm.Input;
using _253504_Noskovich.Application.ProductUseCases.Commands;

namespace _253504_Noskovich.UI.ViewModels;

[QueryProperty(nameof(Product), "product")]  // Передача объекта product на страницу
public partial class ProductDetailsViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    public ProductDetailsViewModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ObservableProperty]
    Product product;

    [RelayCommand]
    async Task EditProductItem() => await GoToEditProductPage();

    [RelayCommand]
    async Task DeleteProductItem() => await DeleteProduct();

    [RelayCommand]
    async Task SetImage() => await SelectImageFromDevice();

    private async Task GoToEditProductPage()
    {
        IDictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"product", Product }
        };
        await Shell.Current.GoToAsync(nameof(EditProduct), parameters);
    }
    private async Task SelectImageFromDevice()
    {
        var pickedImage = await FilePicker.Default.PickAsync(PickOptions.Images);
        if (pickedImage is null) return;

        var fileType = pickedImage.ContentType.Split('/')[1];
        if (fileType is null || Product is null)
        {
            return;
        }
        var dirPath = "D:\\c#\\253504_Noskovich\\253504_Noskovich.UI\\Images\\";
        var pathToImage = Path.Combine(dirPath, $"{(int)Product.Id}.{fileType}");
        pathToImage = Path.Combine(FileSystem.Current.AppDataDirectory, pathToImage);
        using Stream inputStream = await pickedImage.OpenReadAsync();
        if (File.Exists(pathToImage))
        {
            File.Delete(pathToImage);
        }
        using Stream outputStream = File.Create(pathToImage);

        await inputStream.CopyToAsync(outputStream);
        this.OnPropertyChanged(nameof(Product));
    }
    private async Task DeleteProduct()
    {
        var deleteQuery = new DeleteProductQuery(Product);
        await _mediator.Send(deleteQuery);
        await Shell.Current.GoToAsync(nameof(BrandsList));
    }
}