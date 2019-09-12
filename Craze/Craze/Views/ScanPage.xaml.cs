using Craze.Domain;
using Craze.Utility.Exceptions;
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
    public partial class ScanPage
    {
        public ScanPage()
        {
            InitializeComponent();
            Scanner.Options.DelayBetweenContinuousScans = 5000;
        }

        private async void qrScanner_OnResult(ZXing.Result e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try {
                    Animal animal = JsonConvert.DeserializeObject<Animal>(e.Text);
                    App.Database.InsertAnimal(animal);

                    DisplayAlert("Congrats", "New Fossie Scanned!", "OK");
                }
                catch (JsonException) {
                    DisplayAlert("Error", "QR-Code not recognized as Fossie", "OK");
                }
                catch (DuplicateEntryException) {
                    DisplayAlert("Error", "Fossie Already scanned", "OK");
                }
            });

        }

        private async void btnFossies_Clicked(object sender, EventArgs e)
        {
            Scanner.OnScanResult -= qrScanner_OnResult;
            await Navigation.PushAsync(new MyZooPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Scanner.OnScanResult += qrScanner_OnResult;
        }
    }
}