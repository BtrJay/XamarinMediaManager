using BuildIt;
using MediaMvvmcrossForms.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MediaMvvmcrossForms.ViewModels
{
    public class MainViewModel : MvxMasterDetailViewModel<FirstViewModel>
    {
        private ICommand selectedMenuItemChangedCommand;
        private MenuItem selectedMenuItem;

        public MainViewModel()
        {
            Menu.Fill(new[]
            {
                NavigationMenuItem<FirstViewModel>(),
                NavigationMenuItem<SecondViewModel>()
            });
        }

        public MenuItem SelectedMenuItem
        {
            get => selectedMenuItem;
            set
            {
                if (SetProperty(ref selectedMenuItem, value))
                {
                    NavigateToMenuItem(value);
                }
            }
        }

        public ObservableCollection<MenuItem> Menu { get; } = new ObservableCollection<MenuItem>();

        public ICommand SelectedMenuItemChangedCommand => selectedMenuItemChangedCommand ?? (selectedMenuItemChangedCommand = new MvxCommand<MenuItem>(NavigateToMenuItem));

        public override void RootContentPageActivated()
        {
            // When user go backs to root page in NavigationPage (using UI back or changing option in Menu)
            // we unset the SelectedItem of our list
            SelectedMenuItem = null;
        }

        private void NavigateToMenuItem(MenuItem item)
        {
            if (item == null)
            {
                return;
            }

            var vmType = item.ViewModelType;

            // We demand to clear the Navigation stack as we are changing the section
            var presentationBundle = new MvxBundle(new Dictionary<string, string> { { Common.Constants.NavigationMode, Common.Constants.NavigationClearStack } });

            // Show the ViewModel in the Detail NavigationPage
            ShowViewModel(vmType, presentationBundle: presentationBundle);
        }

        private MenuItem NavigationMenuItem<TViewModel>()
        {
            return new MenuItem { Title = Common.Constants.Titles[typeof(TViewModel)], ViewModelType = typeof(TViewModel) };
        }
    }
}