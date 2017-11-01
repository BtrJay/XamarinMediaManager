using MediaMvvmcrossForms.Views.Initialiser;
using MvvmCross.Forms.Core;
using MvvmCross.Forms.Droid.Presenters;
using Xamarin.Forms;

namespace MediaMvvmcrossForms.Droid
{
    public class CustomMvxFormsDroidMasterDetailPagePresenter : MvxFormsDroidMasterDetailPagePresenter, IMasterDetailPresenter
    {
        private MasterDetailPage masterDetailPage;

        public CustomMvxFormsDroidMasterDetailPagePresenter(MvxFormsApplication application)
            : base(application)
        {
        }

        public bool IsPresented
        {
            get => masterDetailPage.IsPresented;
            set => masterDetailPage.IsPresented = value;
        }

        protected override void CustomPlatformInitialization(MasterDetailPage mainPage)
        {
            base.CustomPlatformInitialization(mainPage);
            masterDetailPage = mainPage;
        }
    }
}