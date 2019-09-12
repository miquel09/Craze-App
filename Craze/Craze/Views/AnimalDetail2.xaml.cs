using Craze.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Craze.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AnimalDetail2 : ContentPage
	{
        private Animal Animal;

		public AnimalDetail2 (Animal anAnimal)
		{
            Animal = anAnimal;

            InitializeComponent();
            Fossie.Source = anAnimal.Icon;
            Name.Text = anAnimal.Name;
            Description.Text = anAnimal.Description;

            Play.CommandParameter = anAnimal.VideoId;
		}

        private async void Play_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoPage(Animal.VideoId));
        }
    }
}