using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestApp.ViewModels
{
    public class BaseModelView : INotifyPropertyChanged
    {
        public BaseModelView()
        {
        }

        ~BaseModelView()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
