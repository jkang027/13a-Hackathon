using HackathonGames.Core;
using HackathonGames.Core.Domain;
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
        public Result currentlySelectedResultFrom;

        public GameDetailsWindow(bool isFromMainWindow)
        {
            InitializeComponent();
            
            if (isFromMainWindow)
            {
                currentlySelectedResultFrom = MainWindow.currentlySelectedResult;
            }
            else
            {
                currentlySelectedResultFrom = MyListWindow.currentlySelectedResult;
            }

            textBlockName.Text = currentlySelectedResultFrom.name;
            textBlockDeck.Text = currentlySelectedResultFrom.deck;

            //If there are currentlySelectedResult.platforms, show them. Else, show "not available"
            if (currentlySelectedResultFrom.platforms.Count > 0)
            {
                for (var i = 0; i < currentlySelectedResultFrom.platforms.Count; i++)
                {
                    textBlockPlatforms.Text += currentlySelectedResultFrom.platforms[i].name + "\n";
                }
            }
            else
            {
                textBlockPlatforms.Text = "Currently unavailable";
            }

            //If currentlySelectedResult.releaseDate is not empty, show it. Else show "not available"
            if (!string.IsNullOrEmpty(currentlySelectedResultFrom.original_release_date))
            {
                DateTime releaseDate = DateTime.Parse(currentlySelectedResultFrom.original_release_date);
                textBlockReleaseDate.Text = "Release Date: " + releaseDate.Year + "-" + releaseDate.Month + "-" + releaseDate.Day;
            }
            else
            {
                textBlockReleaseDate.Text = "Release date currently unavailable.";
            }
            
            //If currentlySelectedResult.description is not empty, show it. Else, show "not available"
            if(!string.IsNullOrEmpty(currentlySelectedResultFrom.description))
            {
                webBrowserDescription.NavigateToString(currentlySelectedResultFrom.description);
            }
            else
            {
                webBrowserDescription.NavigateToString("<h1>No description currently available.");
            }

            //If currentlySelectedResult.image.super_url is not empty, show it. Else, show "image not available" image.
            if (!string.IsNullOrEmpty(currentlySelectedResultFrom.image.super_url))
            {
                if (!File.Exists(currentlySelectedResultFrom.image.super_url))
                {
                    using (var webClient = new WebClient())
                    {
                        byte[] bytes = webClient.DownloadData(currentlySelectedResultFrom.image.super_url);
                        File.WriteAllBytes(currentlySelectedResultFrom.image + ".png", bytes);
                    }
                }
                image.Source = new BitmapImage(new Uri(currentlySelectedResultFrom.image.super_url));
            }
            else
            {
                if (!File.Exists("http://vignette3.wikia.nocookie.net/wiisportsresortwalkthrough/images/6/60/No_Image_Available.png/revision/latest?cb=20140118173446"))
                {
                    using (var webClient = new WebClient())
                    {
                        byte[] bytes = webClient.DownloadData("http://vignette3.wikia.nocookie.net/wiisportsresortwalkthrough/images/6/60/No_Image_Available.png/revision/latest?cb=20140118173446");
                        File.WriteAllBytes(currentlySelectedResultFrom.image + ".png", bytes);
                    }
                }
                image.Source = new BitmapImage(new Uri("http://vignette3.wikia.nocookie.net/wiisportsresortwalkthrough/images/6/60/No_Image_Available.png/revision/latest?cb=20140118173446"));
            }
        }

        //Check if game already exists in your list. If it does, give message. 
        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool gameInMyList = false;
            for (var i = 0; i < GameSearch.myList.Count; i++)
            {
                if(GameSearch.myList[i].name == currentlySelectedResultFrom.name)
                {
                    gameInMyList = true;
                }
            }
            if (gameInMyList)
            {
                MessageBox.Show("This game already exists in your \"List\"");
            }
            else
            {
                GameSearch.myList.Add(currentlySelectedResultFrom);
                MessageBox.Show("Game has been added to your \"List\"");
            }
        }
    }
}
