using _253504_Noskovich.UI.ViewModels;
namespace _253504_Noskovich.UI.Pages;

public partial class ProductDetails : ContentPage
{
    public ProductDetails(ProductDetailsViewModel productDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = productDetailsViewModel;
    }
}