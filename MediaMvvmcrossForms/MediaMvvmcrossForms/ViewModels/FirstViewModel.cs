using MediaMvvmcrossForms.Services.Interfaces;

namespace MediaMvvmcrossForms.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public FirstViewModel(IPlaybackService playbackService) : base(playbackService)
        {
        }
    }
}