using System;
using System.Windows;
using System.Windows.Controls;

namespace MicrowaveOven
{
    public class Table : Container
    {
        public Table()
        {
            MaxProductCount = 12;
            left = Canvas.GetLeft(Transfer.TableWindowTextBlock);
            top = Canvas.GetTop(Transfer.TableWindowTextBlock) + 40;
        }

        public override void Working()
        {
            if (productList.Count > 0)
            {
                foreach (Product p in productList)
                {
                    p.ChangeTemperature(-1);
                }
            }
        }

        private void MessageThereIsNoPlace()
        {
            MessageBox.Show("На столе нет места");
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

        public void CreateNewProductAndAddInList(string productType)
        {
            if (ProductListHasAPlace())
            {
                Product newProduct = GetNewProductWithType(productType);
                newProduct.State = State.InTable;
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

        protected override void UpdateVisualList()
        {
            for (int i = 0; i < productList.Count; i++)
            {
                productList[i].SetIconLocation(left + i * IconsHorizontalDistance, top);
            }
        }
    }
}
