using MediaMvvmcrossForms.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Plugin.MediaManager;

namespace MediaMvvmcrossForms
{
    public class MvvmcrossApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes().EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.LazyConstructAndRegisterSingleton(() => CrossMediaManager.Current);

            RegisterNavigationServiceAppStart<MainViewModel>();
        }
    }
}