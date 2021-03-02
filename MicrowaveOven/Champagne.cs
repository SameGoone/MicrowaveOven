using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MicrowaveOven
{
    class Champagne : Product
    {
        bool isOpen = false;
        public Champagne()
        {
            Name = "Шампанское";
            PictureSource = new BitmapImage(new Uri("Resources/ChampagnePicture.png", UriKind.Relative));
            SetIcon();
        }

        public override void ChangeTemperature(int deltaTemperature)
        {
            if (!isOpen)
            {
                if (Temperature + deltaTemperature >= MAX_TEMPERATURE)
                {
                    AsyncCRASH();
                }
                else if (Temperature + deltaTemperature < MIN_TEMPERATURE)
                {
                    Temperature = MIN_TEMPERATURE;
                }
                else
                {
                    Temperature += deltaTemperature;
                }
                Icon.UpdateTemperatureField();
            }
        }

        private async void AsyncCRASH()
        {
            await Task.Run(() => CRASH());
        }

        private void CRASH()
        {
            isOpen = true;
            SoundPlayer soundPlayer = new SoundPlayer(Properties.Resource1.ChampOpenSound);
            soundPlayer.Load();
            soundPlayer.Play();
            Thread.Sleep(1500);
            Transfer.MainWindow.Close();
        }
    }
}
