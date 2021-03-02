using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MicrowaveOven
{
    public abstract class Container
    {
        public const int MaxRowIconCount = 5;
        protected List<Product> productList;
        protected int IconsVerticalDistance = 120;
        protected int IconsHorizontalDistance = 103;
        protected double left; 
        protected double top;
        public Container()
        {
            productList = new List<Product>();
        }

        public int MaxProductCount { get; protected set; } = MaxRowIconCount * 2;
        
        public int ProductCount
        {
            get
            {
                return productList.Count;
            }
        }

        public List<Product> GetProductList()
        {
            return productList;
        }

        public bool ProductListHasAPlace()
        {
            if (ProductCount < MaxProductCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual void UpdateVisualList()
        {
            for (int i = 0; i < productList.Count; i++)
            {
                if (i < MaxRowIconCount)
                {
                    productList[i].SetIconLocation(left + i * IconsHorizontalDistance, top);
                }
                else
                {
                    productList[i].SetIconLocation(left + (i - MaxRowIconCount) * IconsHorizontalDistance, top + IconsVerticalDistance);
                }
            }
        }

        public abstract void AddProduct(Product p);

        public void DeleteAllProducts()
        {
            var copyProductList = new List<Product>(productList);
            foreach(Product product in copyProductList)
            {
                product.Delete();
            }
        }

        public abstract void Working();

        public void RemoveProduct(Product product)
        {
            productList.Remove(product);
            UpdateVisualList();
        }
    }
}
