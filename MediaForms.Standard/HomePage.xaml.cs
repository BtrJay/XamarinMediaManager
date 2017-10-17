using BuildIt;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MediaForms.Standard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.volumeLabel.Text = "Volume (0-" + CrossMediaManager.Current.VolumeManager.MaxVolume + ")";
            //Initialize Volume settings to match interface
            int.TryParse(this.volumeEntry.Text, out var vol);
            CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
            CrossMediaManager.Current.VolumeManager.Muted = false;
        }

        public double TotalDuration { get; set; }

        public double StreamingPosition { get; set; }

        public bool UserInteractingSlider { get; set; }

        protected override void OnAppearing()
        {
            CrossMediaManager.Current.PlayingChanged += CurrentOnPlayingChanged;
            PropertyChanged += OnPropertyChanged;
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            PropertyChanged -= OnPropertyChanged;
            CrossMediaManager.Current.PlayingChanged -= CurrentOnPlayingChanged;
            base.OnDisappearing();
        }

        private void MainBtn_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MediaFormsPage());
        }

        //private async void PlayAudio_OnClicked(object sender, EventArgs e)
        //{
        //    var mediaFile = new MediaFile
        //    {
        //        Type = MediaFileType.Audio,
        //        Availability = ResourceAvailability.Remote,
        //        Url = "https://audioboom.com/posts/5766044-follow-up-305.mp3"
        //    };
        //    await CrossMediaManager.Current.Play(mediaFile);
        //}

        private async void PlaylistButton_OnClicked(object sender, EventArgs e)
        {
            var list = new List<MediaFile>
            {
                new MediaFile
                {
                    Url = "https://audioboom.com/posts/5766044-follow-up-305.mp3?source=rss&amp;stitched=1",
                    Type = MediaFileType.Audio,
                    Metadata = new MediaFileMetadata
                    {
                        Title = "Test1"
                    }
                },
                new MediaFile
                {
                    Url = "https://media.acast.com/mydadwroteaporno/s3e1-london-thursday15.55localtime/media.mp3",
                    Type = MediaFileType.Audio,
                    Metadata = new MediaFileMetadata
                    {
                        Title = "Test2"
                    }
                },
                new MediaFile
                {
                    Url =
                        "https://audioboom.com/posts/5770261-ep-306-a-theory-of-evolution.mp3?source=rss&amp;stitched=1",
                    Type = MediaFileType.Audio,
                    Metadata = new MediaFileMetadata
                    {
                        Title = "Test3"
                    }
                },
                new MediaFile
                {
                    Url = "https://audioboom.com/posts/5723344-ep-304-the-4th-dimension.mp3?source=rss&amp;stitched=1",
                    Type = MediaFileType.Audio,
                    Metadata = new MediaFileMetadata
                    {
                        Title = "Test4"
                    }
                }
            };
            // Follow-Up 305
            // Ep. 306: A Theory of Evolution
            // Ep. 304: The 4th Dimension
            await CrossMediaManager.Current.Play(list);
        }

        private void SetVolumeBtn_OnClicked(object sender, EventArgs e)
        {
            int.TryParse(this.volumeEntry.Text, out var vol);
            CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
        }

        private void MutedBtn_OnClicked(object sender, EventArgs e)
        {
            if (CrossMediaManager.Current.VolumeManager.Muted)
            {
                CrossMediaManager.Current.VolumeManager.Muted = false;
                mutedBtn.Text = "Mute";
            }
            else
            {
                CrossMediaManager.Current.VolumeManager.Muted = true;
                mutedBtn.Text = "Unmute";
            }
        }

        private void CurrentOnPlayingChanged(object sender, PlayingChangedEventArgs e)
        {
            try
            {
                TotalDuration = e.Duration.TotalSeconds;
                StreamingPosition = e.Position.TotalSeconds;
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(TotalDuration)));
                OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(StreamingPosition)));
            }
            catch (Exception ex)
            {
            }
        }

        //private double ScrubbingValue;
        public const double Threadshold = 1;

        private CancellationTokenSource cancellationToken;

        private async void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            try
            {
                var currentValue = e.OldValue;
                var valueToUpdate = e.NewValue;
                var difference = valueToUpdate - currentValue;
                difference = difference < 0 ? difference * -1 : difference;
                if (difference > Threadshold)
                {
                    UserInteractingSlider = true;
                    cancellationToken?.Cancel();
                    cancellationToken = new CancellationTokenSource();

                    await Task.Delay(100, cancellationToken.Token);
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }

                    // Assume that user interacts with slider
                    //await CrossMediaManager.Current.PlaybackController.Pause();
                    await CrossMediaManager.Current.PlaybackController.SeekTo(valueToUpdate);
                    UserInteractingSlider = false;
                    //await CrossMediaManager.Current.PlaybackController.Play();
                }

                //Debug.WriteLine($"Current Streaming Position: {currentValue}");
                //Debug.WriteLine($"New Streaming Position: {valueToUpdate}");
                //if (UserInteractingSlider)
                //{
                //    ScrubbingValue = valueToUpdate;
                //}

                //CrossMediaManager.Current.PlaybackController.Pause();
                //CrossMediaManager.Current.PlaybackController.SeekTo(valueToUpdate);
            }
            catch (Exception ex)
            {
                ex.LogError();
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (UserInteractingSlider)
            {
                return;
            }

            if (e.PropertyName.Equals(nameof(StreamingPosition)))
            {
                PlaybackSlider.Value = StreamingPosition;
            }

            if (e.PropertyName.Equals(nameof(TotalDuration)))
            {
                PlaybackSlider.Maximum = TotalDuration;
            }
        }

        //private void OnSliderTouchEffectAction(object sender, TouchActionEventArgs e)
        //{
        //    if (e.Type == TouchActionType.Pressed)
        //    {
        //        UserInteractingSlider = true;
        //    }

        //    if (e.Type == TouchActionType.Released)
        //    {
        //        UserInteractingSlider = false;

        //        //CrossMediaManager.Current.PlaybackController.Pause();
        //        CrossMediaManager.Current.PlaybackController.SeekTo(PlaybackSlider.Value);
        //        //CrossMediaManager.Current.PlaybackController.Play();
        //        //PlaybackSlider.Value = ScrubbingValue;
        //    }
        //}
    }
}