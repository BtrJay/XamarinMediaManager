using MvvmCross.Core.ViewModels;

namespace MediaMvvmcrossForms.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}