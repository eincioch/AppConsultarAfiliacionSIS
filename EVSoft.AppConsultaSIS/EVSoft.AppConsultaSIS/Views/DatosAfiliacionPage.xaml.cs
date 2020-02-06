using EVSoft.AppConsultaSIS.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EVSoft.AppConsultaSIS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatosAfiliacionPage : ContentPage
    {
        public DatosAfiliacionPage(DatosAfiliacionViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}