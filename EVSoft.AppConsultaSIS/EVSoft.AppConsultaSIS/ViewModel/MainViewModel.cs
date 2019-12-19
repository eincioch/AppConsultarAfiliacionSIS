using EVSoft.AppConsultaSIS.Model;
using EVSoft.AppConsultaSIS.ViewModel.Base;
using EVSoft.AppConsultaSIS.Views;
using EVSoft.Backend.ConsultSIS.Services;
using EVSoft.WebApi.ConsultSIS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EVSoft.AppConsultaSIS.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
		public INavigation Navigation { get; set; }

		private List<TipoDocumento> tipoDocumentos;

		public List<TipoDocumento> TipoDocumentos
		{
			get { return tipoDocumentos; }
			set { tipoDocumentos = value;
				RaisePropertyChanged();
			}
		}

		private TipoDocumento selectedTipoDocumento;

		public TipoDocumento SelectedTipoDocumento
		{
			get { return selectedTipoDocumento; }
			set
			{
				if (selectedTipoDocumento != value)
				{
					selectedTipoDocumento = value;
					RaisePropertyChanged();
				}
			}
		}

		private string _nroDocu;

		public string NroDocu
		{
			get { return _nroDocu; }
			set { _nroDocu = value;
				RaisePropertyChanged();
			}
		}

		public ICommand CommandFind { get; private set; }

		public MainViewModel(INavigation navigation)
		{
			Navigation = navigation;
			TipoDocumentos = TipoDocumentoData.tipoDocumentos;

			CommandFind = new Command<List<AfiliadoEntity>>(async (model) => await Consultar(model).ConfigureAwait(true));
		}

		async Task Consultar(List<AfiliadoEntity> afiliadoEntity)
		{
			try
			{
				if (Validate())
				{
					IsBusy = true;
					ServiceClient serviceClient = new ServiceClient();

					afiliadoEntity = await serviceClient.GetAfiliacionAsync(SelectedTipoDocumento.Id.ToString(), NroDocu);

					if (afiliadoEntity.Count > 0)
						if (afiliadoEntity[0].codError == "0000")

							
							await Navigation.PushModalAsync(new DatosAfiliacionPage(new DatosAfiliacionViewModel(afiliadoEntity[0], Navigation))).ConfigureAwait(true);
						else
							await Application.Current.MainPage.DisplayAlert("Resultado", "Usted NO cuenta con SIS, consulte ha ?", "Aceptar").ConfigureAwait(true);
					else
						await Application.Current.MainPage.DisplayAlert("Error", "Algó salio mal, vuelva a intentarlo", "Aceptar").ConfigureAwait(true);

				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				IsBusy = false;
			}
		}

		private bool Validate() {

			if (SelectedTipoDocumento == null) {
				Application.Current.MainPage.DisplayAlert("Validación", "Seleccione Tipo Documento", "Aceptar");
				return false;
			}

			if (string.IsNullOrEmpty(NroDocu))
			{
				Application.Current.MainPage.DisplayAlert("Validación", "Ingrese nro documento", "Aceptar"); //Resources.AMMsgValidateIDEtiqueta
				return false;
			}
			return true;
		}
	}
}
