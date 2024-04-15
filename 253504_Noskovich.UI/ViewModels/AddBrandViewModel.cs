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
    public partial class AddBrandViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        public AddBrandViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ObservableCollection<Brand> Brands { get; set; } = new();

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        string country;

        [ObservableProperty]
        int year;

        [RelayCommand]
        async Task Enter() => await AddBrandToDb();
        private async Task AddBrandToDb()
        {

            Name ??= string.Empty;
            Description ??= string.Empty;
            Country ??= string.Empty;
            await _mediator.Send(new AddBrandQuery(Name.Trim(), Country.Trim(), Description.Trim(), Year));

            await Shell.Current.GoToAsync(nameof(BrandsList));
        }
    }
}
