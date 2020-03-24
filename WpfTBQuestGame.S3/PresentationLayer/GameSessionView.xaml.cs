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

namespace WpfTheAionProject.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeComponent();
            
        }

        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if(PlayerDataTabControl.SelectedItem!=null)
            {
                _gameSessionViewModel.AddItemToInventory();
            }
        }

        private void PutDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerDataTabControl.SelectedItem != null)
            {
                _gameSessionViewModel.RemoveItemFromInventory();
            }
        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerDataTabControl.SelectedItem != null)
            {
                 _gameSessionViewModel.OnUseGameItem();
            }
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MoveEastButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveEast();
            CurrentLocationName.Text = _gameSessionViewModel.CurrentLocationName;
        }

        private void MoveNorthButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveNorth();
            CurrentLocationName.Text = _gameSessionViewModel.CurrentLocationName;
        }

        private void MoveWestButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveWest();
            CurrentLocationName.Text = _gameSessionViewModel.CurrentLocationName;
        }

        private void MoveSouthButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveSouth();
            CurrentLocationName.Text = _gameSessionViewModel.CurrentLocationName;
        }

        private void WeaponsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
