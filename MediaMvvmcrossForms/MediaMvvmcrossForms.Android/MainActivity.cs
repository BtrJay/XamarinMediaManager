using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Forms.Droid;
using MvvmCross.Forms.Droid.Presenters;
using MvvmCross.Platform;

namespace MediaMvvmcrossForms.Droid
{
    [Activity(Label = "MediaMvvmcrossForms.Android", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // Set up mvvmcross
            var mvxFormsApp = new App();
            LoadApplication(mvxFormsApp);
            var presenter = Mvx.Resolve<IMvxViewPresenter>() as MvxFormsDroidMasterDetailPagePresenter;
            presenter.FormsApplication = mvxFormsApp;
            Mvx.Resolve<IMvxAppStart>().Start();
        }
    }
}