using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MediaMvvmcrossForms.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public FirstViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}