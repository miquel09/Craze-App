﻿using Craze.Domain;
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
	public partial class AnimalDetail : ContentPage
	{
        public AnimalDetail (Animal anAnimal)
		{
            InitializeComponent();

            Name.Text = anAnimal.Name;
            Description.Text = anAnimal.Description;

            string youtubeUrl = "https://www.youtube.com/embed/" + anAnimal.VideoId;

            HtmlWebViewSource personHtmlSource = new HtmlWebViewSource();
            personHtmlSource.SetBinding(HtmlWebViewSource.HtmlProperty, "HTMLDesc");
            personHtmlSource.Html = $@"<html><body>  <div> <iframe style='position: absolute; top: 0; left: 0; width: 100%; height: 100%;'  src='{youtubeUrl}' frameborder='0' allowfullscreen></iframe></div> </body></html>";
            var browser = new WebView();
            browser.Source = personHtmlSource;

            MainElement.Children.Add(browser);
        }
	}
}