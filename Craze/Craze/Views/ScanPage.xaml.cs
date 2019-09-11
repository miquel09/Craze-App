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

                    //createPopUp(animal);
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
            await Navigation.PushAsync(new AnimalList());
        }

        private async void btnFriends_Clicked(object sender, EventArgs e)
        {

        }

        private void createPopUp(Animal animal)
        {
            StackLayout layout = new StackLayout();
            layout.BackgroundColor = Color.Red;
            layout.Margin = 10;

            ContentGrid.Children.Add(layout, 3, 3);
        }
    }
}