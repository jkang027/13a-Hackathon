using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HackathonGames
{
    /// <summary>
    /// Interaction logic for GameDetailsWindow.xaml
    /// </summary>
    public partial class GameDetailsWindow : Window
    {
        public GameDetailsWindow()
        {
            InitializeComponent();
            textBlockName.Text = MainWindow.currentlySelectedResult.name;
            textBlockDeck.Text = MainWindow.currentlySelectedResult.deck;

            //If there are currentlySelectedResult.platforms, show them. Else, show "not available"
            if (MainWindow.currentlySelectedResult.platforms.Count != 0)
            {
                for (var i = 0; i < MainWindow.currentlySelectedResult.platforms.Count; i++)
                {
                    textBlockPlatforms.Text += MainWindow.currentlySelectedResult.platforms[i].name + "\n";
                }
            }
            else
            {
                textBlockPlatforms.Text = "Currently unavailable";
            }

            //If currentlySelectedResult.releaseDate is not empty, show it. Else show "not available"
            if (!string.IsNullOrEmpty(MainWindow.currentlySelectedResult.original_release_date))
            {
                DateTime releaseDate = DateTime.Parse(MainWindow.currentlySelectedResult.original_release_date);
                textBlockReleaseDate.Text = "Release Date: " + releaseDate.Year + "-" + releaseDate.Month + "-" + releaseDate.Day;
            }
            else
            {
                textBlockReleaseDate.Text = "Release date currently unavailable.";
            }
            
            //If currentlySelectedResult.description is not empty, show it. Else, show "not available"
            if(!string.IsNullOrEmpty(MainWindow.currentlySelectedResult.description))
            {
                webBrowserDescription.NavigateToString(MainWindow.currentlySelectedResult.description);
            }
            else
            {
                webBrowserDescription.NavigateToString("<h1>No description currently available.");
            }

            //If currentlySelectedResult.image.super_url is not empty, show it. Else, show "image not available" image.
            if (!string.IsNullOrEmpty(MainWindow.currentlySelectedResult.image.super_url))
            {
                if (!File.Exists(MainWindow.currentlySelectedResult.image.super_url))
                {
                    using (var webClient = new WebClient())
                    {
                        byte[] bytes = webClient.DownloadData(MainWindow.currentlySelectedResult.image.super_url);
                        File.WriteAllBytes(MainWindow.currentlySelectedResult.image + ".png", bytes);
                    }
                }
                image.Source = new BitmapImage(new Uri(MainWindow.currentlySelectedResult.image.super_url));
            }
            //else
            //{
            //    if (!File.Exists("http://vignette3.wikia.nocookie.net/wiisportsresortwalkthrough/images/6/60/No_Image_Available.png/revision/latest?cb=20140118173446"))
            //    {
            //        using (var webClient = new WebClient())
            //        {
            //            byte[] bytes = webClient.DownloadData("http://vignette3.wikia.nocookie.net/wiisportsresortwalkthrough/images/6/60/No_Image_Available.png/revision/latest?cb=20140118173446");
            //            File.WriteAllBytes(MainWindow.currentlySelectedResult.image + ".png", bytes);
            //        }
            //    }
            //    image.Source = new BitmapImage(new Uri("http://vignette3.wikia.nocookie.net/wiisportsresortwalkthrough/images/6/60/No_Image_Available.png/revision/latest?cb=20140118173446"));
            //}
        }
    }
}
