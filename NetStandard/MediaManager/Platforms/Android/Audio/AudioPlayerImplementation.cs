using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;
using Com.Google.Android.Exoplayer2;
using Com.Google.Android.Exoplayer2.Audio;
using Com.Google.Android.Exoplayer2.Extractor;
using Com.Google.Android.Exoplayer2.Source;
using Com.Google.Android.Exoplayer2.Trackselection;
using Com.Google.Android.Exoplayer2.Upstream;
using MediaManager.Abstractions;
using MediaManager.Abstractions.Enums;
using Plugin.MediaManager;

namespace MediaManager.Platforms.Android
{
    public class AudioPlayerImplementation : IAudioPlayer
    {
        private MediaManagerImplementation _mediaManagerImplementation;
        public MediaBrowserCompat mediaBrowser { get; private set; }
        //public MediaSessionCompat MediaSession { get; private set; }
        private MediaControllerCompat mediaController;
        //private ConnectionCallback mConnectionCallback;
        //private MediaControllerCallback mMediaControllerCallback;

        public AudioPlayerImplementation(MediaManagerImplementation mediaManagerImplementation)
        {
            _mediaManagerImplementation = mediaManagerImplementation;

            //mMediaControllerCallback = new MediaControllerCallback();

            // Connect a media browser just to get the media session token. There are other ways
            // this can be done, for example by sharing the session token directly.
            //mConnectionCallback = new ConnectionCallback(() => {
            //    mediaController = new MediaControllerCompat(context, mMediaBrowser.SessionToken);
            //    mediaController.RegisterCallback(mMediaControllerCallback);
            //});

            mediaBrowser = new MediaBrowserCompat(_mediaManagerImplementation.Context, new ComponentName(_mediaManagerImplementation.Context, Java.Lang.Class.FromType(GetType())), new MediaBrowserConnectionCallback(_mediaManagerImplementation), null);
            mediaBrowser.Connect();

            mediaController = new MediaControllerCompat(_mediaManagerImplementation.Context, mediaBrowser.SessionToken);
        }

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

        private SimpleExoPlayer mExoPlayer;

        public Task Pause()
        {
            throw new NotImplementedException();
        }

        public Task Play(string url)
        {

            return Task.CompletedTask;
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
