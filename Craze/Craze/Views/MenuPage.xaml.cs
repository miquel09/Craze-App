using Craze.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Craze.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        ZXingScannerPage scanPage;

        public MenuPage ()
		{
			InitializeComponent ();
		}

        private async void btn_ScanNewCodeClicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {
                    Animal animal = JsonConvert.DeserializeObject<Animal>(result.Text);
                    //TODO Error handling
                    try {
                        App.Database.InsertAnimal(animal);
                        Navigation.PushAsync(new AnimalDetail(animal));
                        Navigation.RemovePage(scanPage);
                    }
                    catch {
                        DisplayAlert("Error", "Animal Code already scanned", "OK");
                        Navigation.PopAsync();
                    }
                });
            };

            await Navigation.PushAsync(scanPage);
        }

        private async void btn_MyAnimalsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AnimalList());
        }

        private void btn_MyZooClicked(object sender, EventArgs e)
        {

        }
    }
}