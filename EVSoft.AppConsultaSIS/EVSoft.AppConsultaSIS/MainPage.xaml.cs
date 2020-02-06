using EVSoft.AppConsultaSIS.ViewModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace EVSoft.AppConsultaSIS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        MainViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = vm = new MainViewModel(this.Navigation);
        }
    }
}
