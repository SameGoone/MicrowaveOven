using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MicrowaveOven
{
    public class Microwave : Container
    {
        public bool IsWorking;
        public bool IsPaused;
        public bool IsWorkTimeInstalling;

        private int power = 1;
        public int InstalledWorkTimeInSeconds { get; set; } = 0;
        public int WorkTimeLeft { get; set; } = 0;


        public Microwave()
        {
            left = Canvas.GetLeft(Transfer.MicrowaveWindowTextBlock);
            top = Canvas.GetTop(Transfer.MicrowaveWindowTextBlock) + 40;
            power = 1;
        }

        public int Power
        {
            get
            {
                return power;
            }
            private set
            {
                if (value >= 1 && value <= 5)
                {
                    power = value;
                }
                else if (value < 1)
                {
                    MessageBox.Show("Установлена минимальная мощность");
                }
                else if (value > 5)
                {
                    MessageBox.Show("Установлена максимальная мощность");
                }
            }
        }

        public void IncreasePower()
        {
            Power += 1;
        }

        public void ReducePower()
        {
            Power -= 1;
        }

        public override void Working()
        {
            if (IsWorking && !IsPaused)
            {
                WorkTimeLeft--;
                if (WorkTimeLeft > 0)
                {
                    foreach (Product p in productList)
                    {
                        p.ChangeTemperature(power);
                    }
                }
                else
                {
                    Off();
                }
            }
            else
            {
                foreach (Product p in productList)
                {
                    p.ChangeTemperature(-1);
                }
            }
        }

        public bool WorkTimeIsNotInstalled()
        {
            if (InstalledWorkTimeInSeconds == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Off()
        {
            InstalledWorkTimeInSeconds = 0;
            WorkTimeLeft = 0;
            IsWorking = false;
            IsPaused = false;
            IsWorkTimeInstalling = false;
            Transfer.Recolorer.RecolorTimeTextBlocks(Brushes.Blue);
        }

        public void On()
        {
            IsWorking = true;
            WorkTimeLeft = InstalledWorkTimeInSeconds;
            IsWorkTimeInstalling = false;
            Transfer.Recolorer.RecolorTimeTextBlocks(Brushes.Red);
        }

        public override void AddProduct(Product p)
        {
            if (ProductListHasAPlace())
            {
                productList.Add(p);
                UpdateVisualList();
            }
            else
            {
                MessageThereIsNoPlace();
            }
        }

        private void MessageThereIsNoPlace()
        {
            MessageBox.Show("В микроволновке нет места");
        }

        public void CreateNewProductAndAddInList(string productType)
        {
            if (ProductListHasAPlace())
            {
                Product newProduct = GetNewProductWithType(productType);
                newProduct.State = State.InMicrowave;
                productList.Add(newProduct);
                UpdateVisualList();
            }
            else
            {
                MessageThereIsNoPlace();
            }
        }

        private Product GetNewProductWithType(string productType)
        {
            switch (productType)
            {
                case "Вода":
                    return new Water();
                case "Суп":
                    return new Soup();
                case "Бургер":
                    return new Burger();
                case "Котлеты":
                    return new Cutlets();
                case "Наггетсы":
                    return new Nuggets();
                case "Молоко":
                    return new Milk();
                case "Шампанское":
                    return new Champagne();
                default:
                    throw new ArgumentException("Неверный тип продукта");
            }

        }
    }
}
