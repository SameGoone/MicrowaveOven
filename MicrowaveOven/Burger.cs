using System;
using System.Windows.Media.Imaging;

namespace MicrowaveOven
{
    public class Burger : Product
    {
        public Burger()
        {
            Name = "Бургер";
            PictureSource = new BitmapImage(new Uri("Resources/BurgerPicture.png", UriKind.Relative));
            SetIcon();
        }
    }
}
