﻿using EVSoft.AppConsultaSIS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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