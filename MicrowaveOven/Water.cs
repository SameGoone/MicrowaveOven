using System;
using System.Windows.Media.Imaging;

namespace MicrowaveOven
{
    public class Water : Product
    {
        public Water()
        {
            Name = "Вода";
            PictureSource = new BitmapImage(new Uri("Resources/WaterPicture.jpg", UriKind.Relative));
            SetIcon();
        }
    }
}
