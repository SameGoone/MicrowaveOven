using System;
using System.Windows.Media.Imaging;

namespace MicrowaveOven
{
    public class Soup : Product
    {
        public Soup()
        {
            Name = "Суп";
            PictureSource = new BitmapImage(new Uri("Resources/SoupPicture.png", UriKind.Relative));
            SetIcon();
        }
    }
}
