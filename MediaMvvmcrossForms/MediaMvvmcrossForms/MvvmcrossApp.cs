using MediaMvvmcrossForms.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace MediaMvvmcrossForms
{
    public class MvvmcrossApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes().EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}