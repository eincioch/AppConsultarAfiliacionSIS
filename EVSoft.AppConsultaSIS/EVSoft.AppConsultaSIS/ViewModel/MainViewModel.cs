using EVSoft.AppConsultaSIS.Model;
using EVSoft.AppConsultaSIS.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EVSoft.AppConsultaSIS.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
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
			set { selectedTipoDocumento = value; }
		}

		private string _nroDocu;

		public string NroDocu
		{
			get { return _nroDocu; }
			set { _nroDocu = value;
				RaisePropertyChanged();
			}
		}


		//public ICommand CommandFind { get; private set; }
		public ICommand CommandFind => new Command(Consultar);

		async void Consultar()
		{
			if (Validate())
			{
				//var result = await _logInService.LogIn(UserName, Password);
				Application.Current.MainPage.DisplayAlert("Hola", "me pulsaste!", "Aceptar").ConfigureAwait(true);
			}
		}

		public MainViewModel()
		{
			IsBusy = true;
			TipoDocumentos = TipoDocumentoData.tipoDocumentos;
			IsBusy = false;

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
