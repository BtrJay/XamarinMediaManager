using BuildIt;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaMvvmcrossForms.Services.Interfaces
{
    public interface IPlaybackService
    {
        event EventHandler<ParameterEventArgs<bool>> IsPlayingChanged;

        event EventHandler<ParameterEventArgs<bool>> IsBufferingChanged;

        event EventHandler<ParameterEventArgs<double>> PlaybackPositionChanged;

        event EventHandler<ParameterEventArgs<MediaPlayerStatus>> StatusChanged;

        bool HasMediaFile { get; }

        double StreamingPosition { get; }

        double TotalDuration { get; }

        Task Pause();

        Task Play();

        Task SeekTo(double streamingPosition);

        Task PlayList(List<MediaFile> mediaFilesList);

        Task Stop();
    }
}