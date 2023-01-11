using System;
using System.Collections.ObjectModel;
using TestApp.Helper;
using TestApp.Models;
using TestApp.Services;

namespace TestApp.ViewModels
{
    public class ImageListViewModel : BaseModelView
    {
        public ImageListViewModel()
        {
            ImageList = new ObservableCollection<ImageModel>();
        }

        private ObservableCollection<ImageModel> _ImageList;

        public ObservableCollection<ImageModel> ImageList
        {
            get => _ImageList;
            set
            {
                _ImageList = value;
                OnPropertyChanged(nameof(ImageList));
            }
        }

        private bool unlimitCalls = true;
        public async void InitModel()
        {
            while (unlimitCalls)
            {
                try
                {
                    var data = await ImageServices.GetImageData(AppSettings.AppGuid);

                    if (data != null)
                        ImageList.Add(data);
                }
                catch (OverflowException)
                {
                    unlimitCalls = false;
                    //ImageList.Clear();
                }
            }
        }
    }
}
