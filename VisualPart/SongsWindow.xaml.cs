using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

namespace VisualPart
{
    public partial class SongsWindow : Window
    {
        SoundPlayer soundPlayer;
        public SongsWindow()
        {
            InitializeComponent();
        }

        private void PlayClassicButton_Click(object sender, RoutedEventArgs e)
        {
            Play(Properties.Resources.Classic);
        }

        private void Play(Stream SoundStream)
        {
            soundPlayer = new SoundPlayer(SoundStream);
            soundPlayer.Load();
            soundPlayer.PlayLooping();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            soundPlayer?.Stop();
        }

        private void PlayBuzovaButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Вы уверены?", "ВНимание!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (answer == MessageBoxResult.Yes)
            {
                MessageBoxResult secondAnswer = MessageBox.Show("ВЫ ТОЧНО УВЕРЕНЫ?", "ВНИМАНИЕ!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (secondAnswer == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Администрация микроволновки не несёт ответственности за моральные и нравственные страдания при прослушивании.", "Мда..", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Play(Properties.Resources.Buzova);
                }
                else
                    MessageBox.Show("Фух..", "фухх..", MessageBoxButton.OK);
            }
            else
                MessageBox.Show("Фух..", "фухх..", MessageBoxButton.OK);
        }

        private void PlayRemixButton_Click(object sender, RoutedEventArgs e)
        {
            Play(Properties.Resources.Coffin);
        }
    }
}
