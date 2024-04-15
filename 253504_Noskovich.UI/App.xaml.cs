using _253504_Noskovich.UI.ViewModels;
namespace _253504_Noskovich.UI.Pages;

public partial class AddProduct : ContentPage
{
    public AddProduct(AddProductViewModel addProductViewModel)
    {
        InitializeComponent();
        BindingContext = addProductViewModel;
    }
}
