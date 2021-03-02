using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrowaveOven
{
    public enum State
    {
        InMicrowave,
        InTable
    }

    public struct Size
    {
        public Size(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Height;
        public double Width;
    }
}
