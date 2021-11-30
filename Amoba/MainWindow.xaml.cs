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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amoba
{
    public partial class MainWindow : Window
    {
        private string value = "x";
        private int xWin = 0;
        private int oWin = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            ButtonReset();
            xWin = 0;
            oWin = 0;
            xWins.Content = "x: 0";
            oWins.Content = "o: 0";
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void bt_Click(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Foreground = Brushes.Red;
            bt.IsEnabled = false;

            if (IsWin(b1, b2, b3)) GameOver(b1.Content.ToString());
            if (IsWin(b4, b5, b6)) GameOver(b4.Content.ToString());
            if (IsWin(b7, b8, b9)) GameOver(b7.Content.ToString());
            if (IsWin(b1, b4, b7)) GameOver(b1.Content.ToString());
            if (IsWin(b2, b5, b8)) GameOver(b2.Content.ToString());
            if (IsWin(b3, b6, b9)) GameOver(b3.Content.ToString());
            if (IsWin(b1, b5, b9)) GameOver(b1.Content.ToString());
            if (IsWin(b3, b5, b7)) GameOver(b3.Content.ToString());

            if (!b1.IsEnabled && !b2.IsEnabled && !b3.IsEnabled &&
                !b4.IsEnabled && !b5.IsEnabled && !b6.IsEnabled &&
                !b7.IsEnabled && !b8.IsEnabled && !b9.IsEnabled)
                GameOver("");
            value = value == "x" ? "o" : "x";
        }
        private void GameOver(string who)
        {
            if (Winner.Visibility == Visibility.Visible) return;
            if (who == "x")
            {
                Winner.Content = "Player x win!";
                xWins.Content = $"X:  {++xWin}";
            }
            else if (who == "o")
            {
                Winner.Content = "Player o win!";
                oWins.Content = $"O:  {++oWin}";
            }
            else Winner.Content = "No winner!";
            Winner.Visibility = Visibility.Visible;
            Restart();
        }
        private async void Restart()
        {
            await Task.Delay(1000);
            Winner.Visibility = Visibility.Hidden;
            ButtonReset();
        }
        private void ButtonReset()
        {
            bReset(b1);
            bReset(b2);
            bReset(b3);
            bReset(b4);
            bReset(b5);
            bReset(b6);
            bReset(b7);
            bReset(b8);
            bReset(b9);
        }
        private void bReset(Button bt)
        {
            bt.Content = "";
            bt.IsEnabled = true;
        }
        private bool IsWin(Button bt1, Button bt2, Button bt3) =>
            !bt1.IsEnabled && bt1.Content == bt2.Content && bt1.Content == bt3.Content;
        private void bt_Enter(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            bt.Content = value;
        }
        private void bt_Leave(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            if (bt.IsEnabled) bt.Content = "";
        }
    }
}
