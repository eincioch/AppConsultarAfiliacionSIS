using EVSoft.AppConsultaSIS.ViewModel.Base;
using EVSoft.Dominio.ConsultSIS.Entities;
using Xamarin.Forms;

namespace EVSoft.AppConsultaSIS.ViewModel
{
	public class DatosAfiliacionViewModel : BaseViewModel
	{
		public INavigation Navigation { get; set; }

		private AfiliadoEntity afiliadoEntity;

		public AfiliadoEntity AfiliadoEntity
		{
			get { return afiliadoEntity; }
			set
			{
				afiliadoEntity = value;
				RaisePropertyChanged();
			}
		}

		public DatosAfiliacionViewModel(AfiliadoEntity afiliadoEntity, INavigation navigation)
		{
			Navigation = navigation;
			AfiliadoEntity = afiliadoEntity;
		}


	}
}
