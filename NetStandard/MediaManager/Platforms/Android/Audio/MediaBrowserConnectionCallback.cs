using System;
using System.Collections.Generic;
using System.Text;
using Android.Support.V4.Media;
using Plugin.MediaManager;

namespace MediaManager.Platforms.Android
{
    public class MediaBrowserConnectionCallback : MediaBrowserCompat.ConnectionCallback
    {
        private MediaManagerImplementation mediaManagerImplementation;

        public MediaBrowserConnectionCallback(MediaManagerImplementation mediaManagerImplementation)
        {
            this.mediaManagerImplementation = mediaManagerImplementation;
        }
    }
}
