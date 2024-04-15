using _253504_Noskovich.UI.ViewModels;
namespace _253504_Noskovich.UI.Pages;

public partial class EditProduct : ContentPage
{
    public EditProduct(EditProductViewModel editProductViewModel)
    {
        InitializeComponent();
        BindingContext = editProductViewModel;
    }
}