using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MicrowaveOven
{
    public abstract class Product
    {
        public const int MIN_TEMPERATURE = 20,
            MAX_TEMPERATURE = 100;

        public State State;

        private string name;
        private BitmapImage pictureSource;
        private int temperature;

        public Icon Icon { get; private set; }
        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Имя продукта не может быть null или пустым");
                }
                name = value;
            }
        }

        public BitmapImage PictureSource
        {
            get
            {
                return pictureSource;
            }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("PictureSource не может быть null");
                }
                pictureSource = value;
            }
        }

        public int Temperature
        {
            get
            {
                return temperature;
            }
            protected set
            {
                if (value > MAX_TEMPERATURE || value < MIN_TEMPERATURE)
                {
                    throw new ArgumentException("Некорректная температура");
                }
                temperature = value;
            }
        }

        public Product()
        {
            Temperature = 25;
        }

        protected void SetIcon()
        {
            Icon = new Icon(this);
        }

        public void SetIconLocation(double left, double top)
        {
            Icon.SetLocation(left, top);
        }

        public void Delete()
        {
            if (State == State.InMicrowave)
            {
                Transfer.Microwave.RemoveProduct(this);
            }
            else
            {
                Transfer.Table.RemoveProduct(this);
            }
            Icon.Delete();
        }

        public virtual void ChangeTemperature(int deltaTemperature)
        {
            if (Temperature + deltaTemperature > MAX_TEMPERATURE)
            {
                Temperature = MAX_TEMPERATURE;
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

        public void ReplaceToTheTable()
        {
            Table table = Transfer.Table;
            if (table.ProductCount < table.MaxProductCount)
            {
                Transfer.Microwave.RemoveProduct(this);
                Transfer.Table.AddProduct(this);
                State = State.InTable;
            }
            else
            {
                MessageBox.Show("На столе нет места");
            }
        }

        public void ReplaceToTheMicrowave()
        {
            Microwave microwave = Transfer.Microwave;
            if (microwave.ProductCount < microwave.MaxProductCount)
            {
                Transfer.Table.RemoveProduct(this);
                Transfer.Microwave.AddProduct(this);
                State = State.InMicrowave;
            }
            else
            {
                MessageBox.Show("В микроволновке нет места");
            }
        }
    }
}
