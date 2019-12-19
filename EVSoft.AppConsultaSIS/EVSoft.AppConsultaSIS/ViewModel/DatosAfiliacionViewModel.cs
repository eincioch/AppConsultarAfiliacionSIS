using EVSoft.AppConsultaSIS.ViewModel.Base;
using EVSoft.WebApi.ConsultSIS.Model;
using System;
using System.Collections.Generic;
using System.Text;
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
			set { afiliadoEntity = value;
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
