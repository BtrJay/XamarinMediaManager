using Android.Content;
using MediaMvvmcrossForms.Views;
using MediaMvvmcrossForms.Views.Initialiser;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Droid;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Platform.Platform;
using Xamarin.Forms;

namespace MediaMvvmcrossForms.Droid
{
    public class Setup : MvxFormsAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new MvvmcrossApp();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var presenter = new CustomMvxFormsDroidMasterDetailPagePresenter(FormsApplication);
            Mvx.RegisterSingleton<IMvxViewPresenter>(presenter);
            Mvx.RegisterSingleton<IMasterDetailPresenter>(presenter);

            return presenter;
        }

        protected override MvxFormsApplication CreateFormsApplication()
        {
            if (!Forms.IsInitialized)
            {
                var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
                Forms.Init(activity, null);
            }

            return new App();
        }

        protected override void InitializeViewLookup()
        {
            base.InitializeViewLookup();

            var initializer = Mvx.Resolve<IViewLookupInitialiser>();
            initializer?.InitializeViewLookup();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.LazyConstructAndRegisterSingleton<IViewLookupInitialiser, FormsViewLookupInitializer>();
        }
    }
}