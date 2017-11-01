using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;
using Xamarin.Forms;

namespace MediaMvvmcrossForms.Droid
{
    [Activity(Label = "MediaMvvmcrossForms.Android", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        private bool isInitializationComplete = false;

        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

        public override void InitializationComplete()
        {
            if (!isInitializationComplete)
            {
                isInitializationComplete = true;
                var intent = new Intent(this, typeof(MainActivity));
                intent.SetData(Intent.Data);
                StartActivity(intent);
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            // Leverage controls' StyleId attrib. to Xamarin.UITest
            Forms.ViewInitialized += (sender, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.View.StyleId))
                {
                    e.NativeView.ContentDescription = e.View.StyleId;
                }
            };

            base.OnCreate(bundle);
        }
    }
}