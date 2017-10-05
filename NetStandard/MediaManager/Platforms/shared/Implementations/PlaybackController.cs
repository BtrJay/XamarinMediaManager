using System;
using System.Threading.Tasks;
using MediaManager.Abstractions.Enums;

namespace MediaManager.Abstractions.Implementations
{
    public class PlaybackController: IPlaybackController
    {
        private MediaManagerBase mediaManagerBase;

        public PlaybackController()
        {
        }

        public PlaybackController(MediaManagerBase mediaManagerBase)
        {
            this.mediaManagerBase = mediaManagerBase;
        }

        public Task PlayFromQueueByIndex(int index)
        {
            throw new NotImplementedException();
        }

        public Task PlayFromQueueByMediaFile(IMediaItem file)
        {
            throw new NotImplementedException();
        }

        public Task SeekForward(TimeSpan? time = null)
        {
            throw new NotImplementedException();
        }

        public Task SeekBackward(TimeSpan? time = null)
        {
            throw new NotImplementedException();
        }

        public Task SeekTo(TimeSpan position)
        {
            throw new NotImplementedException();
        }

        public void SetRepeatMode(RepeatMode type)
        {
            throw new NotImplementedException();
        }

        public void SetShuffleMode(ShuffleMode type)
        {
            throw new NotImplementedException();
        }

        public void SetRating()
        {
            throw new NotImplementedException();
        }

        public Task Play()
        {
            throw new NotImplementedException();
        }

        public Task Pause()
        {
            throw new NotImplementedException();
        }

        public Task PlayPause()
        {
            throw new NotImplementedException();
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }

        public Task PlayPreviousOrSeekToStart()
        {
            throw new NotImplementedException();
        }

        public Task PlayPrevious()
        {
            throw new NotImplementedException();
        }

        public Task PlayNext()
        {
            throw new NotImplementedException();
        }

        public Task SeekToStart()
        {
            throw new NotImplementedException();
        }
    }
}
