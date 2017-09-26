using System;
using System.Collections.Generic;
using System.Text;
using MediaManager.Abstractions;
using Plugin.MediaManager;

namespace MediaManager.Platforms.Android
{
    public class VolumeManagerImplementation : IVolumeManager
    {
        private MediaManagerImplementation mediaManagerImplementation;

        public VolumeManagerImplementation(MediaManagerImplementation mediaManagerImplementation)
        {
            this.mediaManagerImplementation = mediaManagerImplementation;
        }

        public float CurrentVolume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float MaxVolume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Mute { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event VolumeChangedEventHandler VolumeChanged;
    }
}
