using MediaMvvmcrossForms.Services.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaMvvmcrossForms.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        private IMvxNavigationService navService;
        private ICommand navigateCommand;

        public FirstViewModel(IMvxNavigationService navService, IPlaybackService playbackService) : base(playbackService)
        {
            this.navService = navService;
        }

        public ICommand NavigateCommand => navigateCommand ?? (navigateCommand = new MvxAsyncCommand(NavigateToSecondPage));

        private async Task NavigateToSecondPage()
        {
            await navService.Navigate<SecondViewModel>();
        }
    }
}