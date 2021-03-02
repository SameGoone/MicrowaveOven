using System;
using System.Windows;
using System.Windows.Controls;

namespace MicrowaveOven
{
    public class Transfer
    {
        public const string PATH_OF_SAVES = "saves.xml";
        private static Recolorer recolorer;
        private static TextBlock microwaveWindowTextBlock;
        private static TextBlock tableWindowTextBlock;
        private static Canvas canvas;
        private static Microwave microwave;
        private static Table table;
        private static Window mainWindow;
        public static Canvas Canvas
        {
            get
            {
                return canvas;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                canvas = value;
            }
        }

        public static Microwave Microwave
        {
            get
            {
                return microwave;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ссылка на экземпляр Microwave не может быть пустой");
                }
                microwave = value;
            }
        }

        public static Table Table
        {
            get
            {
                return table;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ссылка на экземпляр Table не может быть пустой");
                }
                table = value;
            }
        }

        public static Recolorer Recolorer
        {
            get
            {
                return recolorer;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ссылка на экземпляр Recolorer не может быть пустой");
                }
                recolorer = value;
            }
        }

        public static TextBlock MicrowaveWindowTextBlock
        {
            get
            {
                return microwaveWindowTextBlock;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ссылка на экземпляр TextBlock (MicrowaveWindowTextBlock) не может быть пустой");
                }
                microwaveWindowTextBlock = value;
            }
        }

        public static TextBlock TableWindowTextBlock
        {
            get
            {
                return tableWindowTextBlock;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ссылка на экземпляр TextBlock (TableWindowTextBlock) не может быть пустой");
                }
                tableWindowTextBlock = value;
            }
        }

        public static Window MainWindow
        {
            get
            {
                return mainWindow;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ссылка на экземпляр MainWindow не может быть пустой");
                }
                mainWindow = value;
            }
        }
    }
}
