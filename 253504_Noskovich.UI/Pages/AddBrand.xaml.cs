using _253504_Noskovich.UI.ViewModels;
namespace _253504_Noskovich.UI.Pages;

public partial class AddBrand : ContentPage
{
    public AddBrand(AddBrandViewModel addBrandViewModel)
    {
        InitializeComponent();
        BindingContext = addBrandViewModel;
    }
}