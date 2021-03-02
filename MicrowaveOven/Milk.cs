using System;
using System.Windows.Media.Imaging;

namespace MicrowaveOven
{
    public class Milk : Product
    {
        public Milk()
        {
            Name = "Молоко";
            PictureSource = new BitmapImage(new Uri("Resources/MilkPicture.png", UriKind.Relative));
            SetIcon();
        }
    }
}
