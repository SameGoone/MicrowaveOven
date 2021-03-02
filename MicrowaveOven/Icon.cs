using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace MicrowaveOven
{
    public class Icon
    {
        private Product parent;
        private Size defaultSize = new Size(70, 70);
        private Size biggerSize = new Size(73, 73);
        private TextBlock temperatureField;
        private Image productPicture;
        private DockPanel panel;
        private Border border;
        private Popup popup;
        public Icon(Product parent)
        {
            this.parent = parent;
            panel = new DockPanel() { };
            productPicture = new Image()
            {
                Source = this.parent.PictureSource,
                Stretch = Stretch.Fill,
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = defaultSize.Width,
                Height = defaultSize.Height
            };
            temperatureField = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Center, FontSize = 20 };
            border = new Border() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black, Child = productPicture };

            DockPanel.SetDock(border, Dock.Top);
            DockPanel.SetDock(temperatureField, Dock.Top);
            panel.Children.Add(border);
            panel.Children.Add(temperatureField);
            Transfer.Canvas.Children.Add(panel);
            Canvas.SetZIndex(panel, 1);

            panel.MouseEnter += Panel_MouseEnter;
            panel.MouseLeave += Panel_MouseLeave;
            panel.MouseLeftButtonDown += Panel_MouseClick;
            panel.MouseRightButtonDown += Panel_MouseRightButtonDown;
            UpdateTemperatureField();
        }

        public void Delete()
        {
            Transfer.Canvas.Children.Remove(panel);
        }

        private void Panel_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            StackPanel popupPanel = new StackPanel();
            var deleteProductButton = new Button { Content = "Удалить", FontSize = 14, Width = 70, Height = 30 };
            popupPanel.Children.Add(deleteProductButton);

            popup = new Popup()
            {
                StaysOpen = false,
                Child = popupPanel,
                Placement = PlacementMode.MousePoint,
                IsOpen = true
            };
            deleteProductButton.Click += DeleteProductButton_Click;
            void DeleteProductButton_Click(object send, RoutedEventArgs ee)
            {
                if (parent.State == State.InMicrowave)
                {
                    var microwave = Transfer.Microwave;
                    if (!microwave.IsWorking || microwave.IsPaused)
                        DeleteParentProductAndClosePopup();

                    else
                        MessageBox.Show("Вы не можете удалить продукт из микроволновой печи во время её работы.");

                }
                else
                    DeleteParentProductAndClosePopup();
            }
        }

        private void DeleteParentProductAndClosePopup()
        {
            parent.Delete();
            popup.IsOpen = false;
        }

        private void Panel_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            productPicture.Height = defaultSize.Height;
            productPicture.Width = defaultSize.Width;
        }

        private void Panel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            productPicture.Height = biggerSize.Height;
            productPicture.Width = biggerSize.Width;
        }

        private void Panel_MouseClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var microwave = Transfer.Microwave;
            if (!microwave.IsWorking || microwave.IsPaused)
            {
                if (parent.State == State.InMicrowave)
                {
                    parent.ReplaceToTheTable();
                }
                else
                {
                    parent.ReplaceToTheMicrowave();
                }
            }
            else
            {
                MessageBox.Show("Вы не можете извлечь или добавить продукт в микроволновую печь во время её работы.");
            }
        }

        public void UpdateTemperatureField()
        {
            temperatureField.Text = $"{parent.Temperature} C°";
        }

        public void SetLocation(double left, double top)
        {
            panel.Margin = new Thickness(left, top, 0, 0);
        }
    }
}
