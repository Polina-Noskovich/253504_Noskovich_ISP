using _253504_Noskovich.UI.Pages;
namespace _253504_Noskovich.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProductDetails), typeof(ProductDetails));
            Routing.RegisterRoute(nameof(AddBrand), typeof(AddBrand));
            Routing.RegisterRoute(nameof(BrandsList), typeof(BrandsList));
            Routing.RegisterRoute(nameof(AddProduct), typeof(Product));
            Routing.RegisterRoute(nameof(EditProduct), typeof(EditProduct));
        }
    }
}