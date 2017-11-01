using BuildIt;
using MediaMvvmcrossForms.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaMvvmcrossForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private BaseViewModel BaseViewModel => (BaseViewModel)ViewModel;

        public double StreamingPosition => BaseViewModel?.StreamingPosition ?? 0;

        public double TotalDuration => BaseViewModel?.TotalDuration ?? 1;

        public bool IsUserSeeking => BaseViewModel?.IsUserSeeking ?? false;

        private CancellationTokenSource cancellationToken;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BaseViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        protected override void OnDisappearing()
        {
            BaseViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            base.OnDisappearing();
        }

        private async void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (PlaybackSlider.Value == 1d)
            {
                return;
            }

            if (ViewModel != null)
            {
                var currentValue = StreamingPosition;
                var valueToUpdate = PlaybackSlider.Value;
                var difference = valueToUpdate - currentValue;
                difference = difference < 0 ? difference * -1 : difference;
                if (difference > 5)
                {
                    try
                    {
                        BaseViewModel.IsUserSeeking = true;
                        cancellationToken?.Cancel();
                        cancellationToken = new CancellationTokenSource();

                        await Task.Delay(50, cancellationToken.Token);
                        if (cancellationToken.IsCancellationRequested)
                        {
                            return;
                        }

                        await BaseViewModel.SeekAsync(valueToUpdate);
                        BaseViewModel.StreamingPosition = valueToUpdate;

                        // Disable visual updates to the progress slider until well after the seek operation has had time to sort itself out
                        await Task.Delay(1500);
                        BaseViewModel.IsUserSeeking = false;
                    }
                    catch (TaskCanceledException)
                    {
                        // We don't care about these.
                    }
                    catch (Exception ex)
                    {
                        ex.LogError();
                    }
                }
            }
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(BaseViewModel.TotalDuration))
            {
                PlaybackSlider.Maximum = TotalDuration;
            }

            if (BaseViewModel.IsUserSeeking)
            {
                return;
            }

            if (e.PropertyName == nameof(BaseViewModel.StreamingPosition))
            {
                PlaybackSlider.Value = StreamingPosition;
            }
        }
    }
}