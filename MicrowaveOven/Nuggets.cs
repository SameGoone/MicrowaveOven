using System;
using System.Windows.Media.Imaging;

namespace MicrowaveOven
{
    public class Nuggets : Product
    {
        public Nuggets()
        {
            Name = "Наггетсы";
            PictureSource = new BitmapImage(new Uri("Resources/NuggetsPicture.png", UriKind.Relative));
            SetIcon();
        }
    }
}
