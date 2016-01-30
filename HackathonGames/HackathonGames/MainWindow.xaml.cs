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
        public static ObservableCollection<Result> gameSearchResult = new ObservableCollection<Result>();

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = gameSearchResult;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            gameSearchResult.Clear();
            var result = GameSearch.getGameSearchResultsFor("\"" + textBoxGameNameSearch.Text + "\"");
            for (int i = 0; i < result.results.Count; i++)
            {
                gameSearchResult.Add(result.results[i]); 
            }
        }

        public static Result currentlySelectedResult = null;
        public void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentlySelectedResult = (Result)dataGrid.SelectedItem;
        }
        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GameDetailsWindow gameDetailsWindow = new GameDetailsWindow();
            gameDetailsWindow.Show();
        }
    }
}
