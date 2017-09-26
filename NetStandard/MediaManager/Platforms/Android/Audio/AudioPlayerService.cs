using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Android.Icu.Util;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;

namespace MediaManager.Platforms.Android
{
    [Service(Name = nameof(AudioPlayerService), Exported = true)]
    [IntentFilter(new[] { MediaBrowserServiceCompat.ServiceInterface })]
    public class AudioPlayerService : MediaBrowserServiceCompat
    {
        public AudioPlayerService()
        {
        }

        protected AudioPlayerService(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        private MediaSessionCompat _mediaSession;

        public override void OnCreate()
        {
            base.OnCreate();

            // Start a new MediaSession.
            _mediaSession = new MediaSessionCompat(this, this.GetType().Name);
            SessionToken = _mediaSession.SessionToken;
            _mediaSession.SetCallback(new MediaSessionCallback());
            _mediaSession.SetFlags(MediaSessionCompat.FlagHandlesMediaButtons |
                                   MediaSessionCompat.FlagHandlesTransportControls);


            // This is an Intent to launch the app's UI, used primarily by the ongoing notification.
            //Intent intent = new Intent(context, GetType());
            //intent.AddFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            //PendingIntent pi = PendingIntent.GetActivity(context, REQUEST_CODE, intent,
            //        PendingIntentFlags.UpdateCurrent);
            //mSession.SetSessionActivity(pi);
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            MediaButtonReceiver.HandleIntent(_mediaSession, intent);
            return base.OnStartCommand(intent, flags, startId);
        }

        public override void OnDestroy()
        {
            _mediaSession.Release();
            base.OnDestroy();
        }

        public override BrowserRoot OnGetRoot(string clientPackageName, int clientUid, Bundle rootHints)
        {
            return new BrowserRoot(nameof(ApplicationContext.ApplicationInfo.Name), // Name visible in Android Auto
                 null);
        }

        public override void OnLoadChildren(string parentId, Result result)
        {
            result.SendResult(null);
        }
    }
}
