using HackathonGames.Core;
using HackathonGames.Core.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HackathonGames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GameSearch.LoadFromDisk();
            dataGrid.ItemsSource = GameSearch.gameSearchResult;
        }

        public static Result currentlySelectedResult = null;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GameSearch.SaveToDisk();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GameSearch.SaveToDisk();
        }
        private void MenuItem_Click_Close(object sender, RoutedEventArgs e)
        {
            MainWindow1.Close();
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            GameSearch.gameSearchResult.Clear();
            var result = GameSearch.getGameSearchResultsFor("\"" + textBoxGameNameSearch.Text + "\"");
            textBlockNumberOfResults.Text = result.number_of_total_results + " Results";
            if (result.results.Count > 0)
            {
                for (int i = 0; i < result.results.Count; i++)
                {
                    GameSearch.gameSearchResult.Add(result.results[i]);
                }
            }
            else
            {
                MessageBox.Show("No results for search.");
            }
        }

        public void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentlySelectedResult = (Result)dataGrid.SelectedItem;
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (currentlySelectedResult != null)
            {
                GameDetailsWindow gameDetailsWindow = new GameDetailsWindow(true);
                gameDetailsWindow.ShowDialog();
            }
        }
        
        private void MenuItem_Click_GoToMyList(object sender, RoutedEventArgs e)
        {
            MyListWindow myListWindow = new MyListWindow();
            myListWindow.ShowDialog();
        }

        private void textBoxGameNameSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button_Click(this, new RoutedEventArgs());
            }
        }
    }
}
