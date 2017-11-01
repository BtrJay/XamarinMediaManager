using BuildIt;
using MediaMvvmcrossForms.Services.Interfaces;
using MvvmCross.Core.ViewModels;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaMvvmcrossForms.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        private IPlaybackService playbackService;
        private MediaPlayerStatus mediaStatus;
        private double streamingPosition;
        private bool isUserSeeking;
        private ICommand playCommand;
        private ICommand pauseCommand;

        public BaseViewModel(IPlaybackService playbackService)
        {
            this.playbackService = playbackService;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            playbackService.PlaybackPositionChanged += PlaybackServiceOnPlaybackPositionChanged;
            playbackService.StatusChanged += PlaybackServiceOnStatusChanged;
        }

        public override void ViewDisappearing()
        {
            playbackService.PlaybackPositionChanged -= PlaybackServiceOnPlaybackPositionChanged;
            playbackService.StatusChanged -= PlaybackServiceOnStatusChanged;
            base.ViewDisappearing();
        }

        public ICommand PlayCommand => playCommand ?? (playCommand = new MvxAsyncCommand(PlayAsync));

        public ICommand PauseCommand => pauseCommand ?? (pauseCommand = new MvxAsyncCommand(PauseAsync));

        public bool IsUserSeeking
        {
            get => isUserSeeking;
            set => SetProperty(ref isUserSeeking, value);
        }

        public double StreamingPosition
        {
            get => streamingPosition;
            set => SetProperty(ref streamingPosition, value);
        }

        public double TotalDuration => playbackService.TotalDuration > 0 ? playbackService.TotalDuration : 1;

        public MediaPlayerStatus MediaStatus
        {
            get => mediaStatus;
            set
            {
                SetProperty(ref mediaStatus, value);
                RaisePropertyChanged(() => MediaStatusText);
            }
        }

        public string MediaStatusText => MediaStatus.ToString();

        public bool HasMediaFile => playbackService.HasMediaFile;

        public async Task SeekAsync(double newPosition)
        {
            try
            {
                await playbackService.SeekTo(newPosition);
            }
            catch (Exception ex)
            {
                ex.LogError();
            }
        }

        private async Task PlayAsync()
        {
            if (!HasMediaFile)
            {
                var audioFiles = new List<MediaFile>
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

                await playbackService.PlayList(audioFiles);
                return;
            }

            await playbackService.Play();
        }

        private async Task PauseAsync()
        {
            await playbackService.Pause();
        }

        private void PlaybackServiceOnPlaybackPositionChanged(object sender, ParameterEventArgs<double> e)
        {
            if (IsUserSeeking)
            {
                return;
            }

            StreamingPosition = e.Parameter1;
            RaisePropertyChanged(() => TotalDuration);
        }

        private void PlaybackServiceOnStatusChanged(object sender, ParameterEventArgs<MediaPlayerStatus> e)
        {
            MediaStatus = e.Parameter1;
            RaisePropertyChanged(() => HasMediaFile);
        }
    }
}