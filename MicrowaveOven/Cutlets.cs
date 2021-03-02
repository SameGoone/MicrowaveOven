using System;
using System.Windows.Media.Imaging;

namespace MicrowaveOven
{
    public class Cutlets : Product
    {
        public Cutlets()
        {
            Name = "Котлеты";
            PictureSource = new BitmapImage(new Uri("Resources/CutletsPicture.png", UriKind.Relative));
            SetIcon();
        }
    }
}
