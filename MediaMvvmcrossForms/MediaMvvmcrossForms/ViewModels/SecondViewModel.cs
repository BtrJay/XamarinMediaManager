using MediaMvvmcrossForms.Services.Interfaces;

namespace MediaMvvmcrossForms.ViewModels
{
    public class SecondViewModel : BaseViewModel
    {
        public SecondViewModel(IPlaybackService playbackService) : base(playbackService)
        {
        }
    }
}