using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Abstractions;
using MediaManager.Abstractions.Enums;
using Plugin.MediaManager;

namespace MediaManager.Platforms.Android
{
    public class VideoPlayerImplementation : IVideoPlayer
    {
        private MediaManagerImplementation mediaManagerImplementation;

        public VideoPlayerImplementation(MediaManagerImplementation mediaManagerImplementation)
        {
            this.mediaManagerImplementation = mediaManagerImplementation;
        }

        public IVideoSurface RenderSurface { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsReadyRendering => throw new NotImplementedException();

        public VideoAspectMode AspectMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PlaybackState State => throw new NotImplementedException();

        public TimeSpan Position => throw new NotImplementedException();

        public TimeSpan Duration => throw new NotImplementedException();

        public TimeSpan Buffered => throw new NotImplementedException();

        public Dictionary<string, string> RequestHeaders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event StatusChangedEventHandler Status;
        public event PlayingChangedEventHandler Playing;
        public event BufferingChangedEventHandler Buffering;
        public event MediaFinishedEventHandler Finished;
        public event MediaFailedEventHandler Failed;

        public Task Pause()
        {
            throw new NotImplementedException();
        }

        public Task Play(string url)
        {
            throw new NotImplementedException();
        }

        public Task Play(FileInfo file)
        {
            throw new NotImplementedException();
        }

        public Task Play(Stream stream)
        {
            throw new NotImplementedException();
        }

        public Task Play(IMediaItem item)
        {
            throw new NotImplementedException();
        }

        public Task Seek(TimeSpan position)
        {
            throw new NotImplementedException();
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
