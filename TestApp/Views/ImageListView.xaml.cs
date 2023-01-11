using TestApp.Helper;
using TestApp.ViewModels;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TestApp
{
    public partial class ImageListView : ContentPage
    {
        //ImageListViewModel Model;
        public ImageListView(ImageListViewModel Model)
        {
            InitializeComponent();
            
           // Model = new ImageListViewModel();
            BindingContext = Model;
        }

        protected override void OnAppearing()
        {
            //Model.LoadData();
            base.OnAppearing();           
        }
    }
}
