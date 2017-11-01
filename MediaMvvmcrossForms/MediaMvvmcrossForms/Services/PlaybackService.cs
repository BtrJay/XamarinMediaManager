using BuildIt;
using MediaMvvmcrossForms.Services.Interfaces;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MediaMvvmcrossForms.Services
{
    public class PlaybackService : IPlaybackService
    {
        private readonly IMediaManager mediaManager;

        public PlaybackService(IMediaManager mediaManager)
        {
            this.mediaManager = mediaManager;

            mediaManager.StatusChanged += OnStatusChanged;
            mediaManager.PlayingChanged += OnPlayingChanged;
        }

        public event EventHandler<ParameterEventArgs<bool>> IsPlayingChanged;

        public event EventHandler<ParameterEventArgs<bool>> IsBufferingChanged;

        public event EventHandler PlaybackPositionChanged;

        public event EventHandler<ParameterEventArgs<MediaPlayerStatus>> StatusChanged;

        public bool HasMediaFile => mediaManager?.MediaQueue?.Any() ?? false;

        public double StreamingPosition { get; set; }

        public double TotalDuration { get; set; } = 1;

        public async Task Pause()
        {
            await mediaManager.PlaybackController.Pause();
        }

        public async Task Play()
        {
            await mediaManager.PlaybackController.Play();
        }

        public Task SeekTo(double streamingPosition)
        {
            return mediaManager.PlaybackController.SeekTo(streamingPosition);
        }

        public async Task PlayList(List<MediaFile> mediaFilesList)
        {
            await mediaManager.Play(mediaFilesList);
        }

        public async Task Stop()
        {
            await mediaManager.PlaybackController.Stop();
        }

        private void OnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            try
            {
                var mediaStatus = e.Status;
                Debug.WriteLine($"*** MediaPlayerStatus: {mediaStatus}");

                IsPlayingChanged?.SafeRaise(this, mediaStatus == MediaPlayerStatus.Playing);
                IsBufferingChanged?.SafeRaise(this, mediaStatus == MediaPlayerStatus.Buffering);
                StatusChanged?.SafeRaise(this, e.Status);
            }
            catch (Exception ex)
            {
                ex.LogError();
            }
        }

        private void OnPlayingChanged(object sender, PlayingChangedEventArgs e)
        {
            try
            {
                PlaybackPositionChanged?.SafeRaise(this);

                TotalDuration = e.Duration.TotalSeconds;
                StreamingPosition = e.Position.TotalSeconds;
            }
            catch (Exception ex)
            {
                ex.LogError();
            }
        }
    }
}