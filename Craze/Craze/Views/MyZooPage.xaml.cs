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
    public partial class MyZooPage : ContentPage
    {
        public ICommand AnimalClickedCommand { protected set; get; }

        public MyZooPage()
        {
            InitializeComponent();
            AnimalClickedCommand = new Command<Animal>(animalClicked);
            renderAnimals();
        }

        private void renderAnimals()
        {
            var animals = App.Database.GetAnimals().ToList();

            for (int i = 0; i < 6; i++) {
                ImageButton imgBtn = new ImageButton()
                {
                    CornerRadius = 25,
                    BackgroundColor = Color.White,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                try {
                    imgBtn.Source = animals[i].Icon;
                    imgBtn.Command = new Command<Animal>(animalClicked);
                    imgBtn.CommandParameter = animals[i];
                }
                catch (ArgumentOutOfRangeException) {
                    imgBtn.Source = "questionmark.png";
                }

                switch (i) {
                    case 0:
                        imgBtn.Margin = new Thickness(10, 10, 5, 5);
                        grid1.Children.Add(imgBtn, 0, 0);
                        break;
                    case 1:
                        imgBtn.Margin = new Thickness(5, 10, 10, 5);
                        grid1.Children.Add(imgBtn, 1, 0);
                        break;
                    case 2:
                        imgBtn.Margin = new Thickness(10, 5, 5, 5);
                        grid2.Children.Add(imgBtn, 0, 0);
                        break;
                    case 3:
                        imgBtn.Margin = new Thickness(5, 5, 10, 5);
                        grid2.Children.Add(imgBtn, 1, 0);
                        break;
                    case 4:
                        imgBtn.Margin = new Thickness(10, 5, 5, 10);
                        grid3.Children.Add(imgBtn, 0, 0);
                        break;
                    case 5:
                        imgBtn.Margin = new Thickness(5, 5, 10, 10);
                        grid3.Children.Add(imgBtn, 1, 0);
                        break;
                }
            }
        }

        private async void animalClicked(Animal animal)
        {
            await Navigation.PushAsync(new AnimalDetail2(animal));
        }
    }
}