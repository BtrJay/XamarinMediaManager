using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaManager.Abstractions;
using Plugin.MediaManager;

namespace MediaManager.Platforms.Android
{
    public class MediaExtractorImplementation : IMediaExtractor
    {
        private MediaManagerImplementation mediaManagerImplementation;

        public MediaExtractorImplementation(MediaManagerImplementation mediaManagerImplementation)
        {
            this.mediaManagerImplementation = mediaManagerImplementation;
        }

        public Task<IMediaItem> ExtractMediaInfo(IMediaItem mediaFile)
        {
            throw new NotImplementedException();
        }
    }
}
