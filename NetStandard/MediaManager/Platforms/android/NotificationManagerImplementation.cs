using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V4.Media.Session;
using MediaManager.Abstractions;
using MediaManager.Abstractions.Enums;
using Plugin.MediaManager;
using static Android.Support.V4.Media.App.NotificationCompat;

namespace MediaManager.Platforms.Android
{
    public class NotificationManagerImplementation : INotificationManager
    {
        private static string CHANNEL_ID = "media_playback_channel";
        private MediaManagerImplementation _mediaManagerImplementation;

        public NotificationManagerImplementation(MediaManagerImplementation mediaManagerImplementation)
        {
            _mediaManagerImplementation = mediaManagerImplementation;
        }

        public void StartNotification(IMediaItem mediaFile)
        {
            // You only need to create the channel on API 26 + devices
            //if (Build.VERSION.SdkInt >= Build.VERSION_CODES.O) {
            //    createChannel();
            //}

            /*NotificationCompat.Builder notificationBuilder =
                   new NotificationCompat.Builder(_mediaManagerImplementation.Context, CHANNEL_ID);
            notificationBuilder
                   .SetStyle(
                           new MediaStyle()
                                   .SetMediaSession(_mediaManagerImplementation.MediaSession.SessionToken)
                                   .SetShowCancelButton(true)
                                   .SetCancelButtonIntent(
                                       MediaButtonReceiver.BuildMediaButtonPendingIntent(
                                           _mediaManagerImplementation.Context, PlaybackStateCompat.ActionStop)))
                   //.setColor(ContextCompat.GetColor(mContext, Resource.color.notification_bg))
                   //.setSmallIcon(R.drawable.ic_stat_image_audiotrack)
                   .SetVisibility(NotificationCompat.VisibilityPublic)
                   .SetOnlyAlertOnce(true)
                   //.SetContentIntent(createContentIntent())
                   .SetContentTitle("Album")
                   .SetContentText("Artist")
                   .SetSubText("Song Name")
                   //.SetLargeIcon(MusicLibrary.getAlbumBitmap(mContext, description.getMediaId()))
                   .SetDeleteIntent(MediaButtonReceiver.BuildMediaButtonPendingIntent(
                           mService, PlaybackStateCompat.ActionStop));*/
        }

        public void StopNotifications()
        {
            throw new NotImplementedException();
        }

        public void UpdateNotifications(IMediaItem mediaFile, PlaybackState status)
        {
            throw new NotImplementedException();
        }
        /*
        private void createChannel()
        {
            var mContext = _mediaManagerImplementation.Context;

            NotificationManager
                    mNotificationManager =
                    (NotificationManager)mContext
                            .GetSystemService(Context.NotificationService);
            // The id of the channel.
            string id = CHANNEL_ID;
            // The user-visible name of the channel.
            CharSequence name = "Media playback";
            // The user-visible description of the channel.
            String description = "Media playback controls";
            int importance = NotificationManager.ImportanceLow;
            NotificationChannel mChannel = new NotificationChannel(id, name, importance);
            // Configure the notification channel.
            mChannel.setDescription(description);
            mChannel.setShowBadge(false);
            mChannel.setLockscreenVisibility(Notification.VISIBILITY_PUBLIC);
            mNotificationManager.createNotificationChannel(mChannel);
        }*/
    }
}
