using Craze.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Craze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnimalList : ContentPage
    {

        public AnimalList()
        {
            InitializeComponent();
            AnimalListview.ItemsSource = App.Database.GetAnimals();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) {
                return;
            }
            Animal animal = (Animal)e.SelectedItem;
            Navigation.PushAsync(new AnimalDetail(animal));
        }
    }
}