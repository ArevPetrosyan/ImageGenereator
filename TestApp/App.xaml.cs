using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using TestApp.Helper;
using TestApp.Properties;
using TestApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    public partial class App : Application
    {
        ImageListViewModel Model;
        public App()
        {
            InitializeComponent();
            Model = new ImageListViewModel();
            //Model.InitModel();
            MainPage = new ImageListView(Model);
        }

        protected override void OnStart()
        {
            object val;
            var d = Resources.TryGetValue("AppGUID", out val);
            if (val != null)
            {
                AppSettings.AppGuid = (Guid)val;
            }
            else
            {
                AppSettings.AppGuid = Guid.NewGuid();
                Application.Current.Resources["AppGUID"] = AppSettings.AppGuid;
            }
            //При старте приложение обращается к веб-сервису
            Model.LoadData();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
