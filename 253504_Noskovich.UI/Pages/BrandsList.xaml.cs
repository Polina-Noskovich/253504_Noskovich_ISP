using _253504_Noskovich.UI.ViewModels;
namespace _253504_Noskovich.UI.Pages;

public partial class BrandsList : ContentPage
{
    public BrandsList(BrandsListViewModel brandsListViewModel)
    {
        InitializeComponent();
        BindingContext = brandsListViewModel;
    }
}