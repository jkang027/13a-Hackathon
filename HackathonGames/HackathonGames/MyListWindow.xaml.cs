using HackathonGames.Core;
using HackathonGames.Core.Domain;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace HackathonGames
{
    /// <summary>
    /// Interaction logic for MyListWindow.xaml
    /// </summary>
    public partial class MyListWindow : Window
    {
        public MyListWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = GameSearch.myList;
        }

        public static Result currentlySelectedResult = null;

        public void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentlySelectedResult = (Result)dataGrid.SelectedItem;
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (currentlySelectedResult != null)
            {
                GameDetailsWindow gameDetailsWindow = new GameDetailsWindow(false);
                gameDetailsWindow.ShowDialog();
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            MyListWindow1.Close();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            GameSearch.Delete(currentlySelectedResult);
        }
    }
}
