using MicrowaveOven;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace VisualPart
{
    public partial class MainWindow : Window
    {
        private Recolorer recolorer;
        private Microwave microwave;
        private Table table;
        private DispatcherTimer timer = new DispatcherTimer() { IsEnabled = true, Interval = new TimeSpan(0, 0, 1) };
        private const int SECONDS_IN_MINUTE = 60;
        public MainWindow()
        {
            InitializeComponent();
            recolorer = new Recolorer(MinuteTextBlock, SecondsTextBlock, ColonTextBlock);
            recolorer.RecolorTimeTextBlocks(Brushes.Blue);
            Transfer.Canvas = Canvas;
            Transfer.Recolorer = recolorer;
            Transfer.MicrowaveWindowTextBlock = MicrowaveWindowTextBlock;
            Transfer.TableWindowTextBlock = TableWindowTextBlock;
            Transfer.MainWindow = this;
            microwave = new Microwave();
            table = new Table();
            Transfer.Microwave = microwave;
            Transfer.Table = table;
            UpdateTextBlockWithPower();
            Loader.Load();
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            microwave.Working();
            table.Working();
            UpdateTimeFields();
        }

        private void UpdateTimeFields()
        {
            if (microwave.IsWorking)
            {
                UpdateTimeFieldWithWorkTime(microwave.WorkTimeLeft);
            }
            else if (!microwave.IsWorkTimeInstalling)
            {
                UpdateTimeFieldWithRealTime();
            }
        }

        private void AddWorkTimeButton_Click(object sender, RoutedEventArgs e)
        {
            if (!microwave.IsWorking)
            {
                microwave.IsWorkTimeInstalling = true;
                int addedWorkTimeInSeconds = GetWorkTimeFromButtonContent((Button)sender);
                int installedWorkTimeInSeconds = microwave.InstalledWorkTimeInSeconds + addedWorkTimeInSeconds;
                if (installedWorkTimeInSeconds / SECONDS_IN_MINUTE < 60)
                {
                    microwave.InstalledWorkTimeInSeconds = installedWorkTimeInSeconds;
                    UpdateTimeFieldWithWorkTime(microwave.InstalledWorkTimeInSeconds);
                }
                else
                {
                    MessageBox.Show("Время работы должно быть меньше 60 минут");
                }
            }
        }

        private int GetWorkTimeFromButtonContent(Button button)
        {
            int workTimeInSeconds = 0;
            string content = button.Content.ToString();
            switch (content)
            {
                case "+10 сек":
                    workTimeInSeconds = 10;
                    break;
                case "+1 мин":
                    workTimeInSeconds = 1 * SECONDS_IN_MINUTE;
                    break;
                case "+10 мин":
                    workTimeInSeconds = 10 * SECONDS_IN_MINUTE;
                    break;
            }
            return workTimeInSeconds;
        }

        private void UpdateTimeFieldWithWorkTime(int workTimeInSeconds)
        {
            (int, int) minutesAndSeconds = ConvertSecondsToMinutesAndSeconds(workTimeInSeconds);
            int minutes = minutesAndSeconds.Item1;
            int seconds = minutesAndSeconds.Item2;
            if (ValueHasOneChar(minutes))
            {
                AddNullAndWriteValueToTheField(MinuteTextBlock, minutes);
            }
            else
            {
                WriteValueToTheField(MinuteTextBlock, minutes);
            }

            if (ValueHasOneChar(seconds))
            {
                AddNullAndWriteValueToTheField(SecondsTextBlock, seconds);
            }
            else
            {
                WriteValueToTheField(SecondsTextBlock, seconds);
            }
        }

        private (int, int) ConvertSecondsToMinutesAndSeconds(int workTimeInSeconds)
        {
            int minutes = workTimeInSeconds / SECONDS_IN_MINUTE;
            int seconds = workTimeInSeconds % SECONDS_IN_MINUTE;
            return (minutes, seconds);
        }

        private void UpdateTimeFieldWithRealTime()
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            if (ValueHasOneChar(hour))
            {
                AddNullAndWriteValueToTheField(MinuteTextBlock, hour);
            }
            else
            {
                WriteValueToTheField(MinuteTextBlock, hour);
            }

            if (ValueHasOneChar(minute))
            {
                AddNullAndWriteValueToTheField(SecondsTextBlock, minute);
            }
            else
            {
                WriteValueToTheField(SecondsTextBlock, minute);
            }
        }

        private bool ValueHasOneChar(int value)
        {
            if (value < 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddNullAndWriteValueToTheField(TextBlock field, int value)
        {
            field.Text = $"0{value}";
        }

        private void WriteValueToTheField(TextBlock field, int value)
        {
            field.Text = value.ToString();
        }

        private void UpdateTextBlockWithPower()
        {
            PowerTextBlock.Text = microwave.Power.ToString();
        }

        private void IncreasePowerButton_Click(object sender, RoutedEventArgs e)
        {
            microwave.IncreasePower();
            UpdateTextBlockWithPower();
        }

        private void ReducePowerButton_Click(object sender, RoutedEventArgs e)
        {
            microwave.ReducePower();
            UpdateTextBlockWithPower();
        }

        private void StartMicrowaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (microwave.ProductCount == 0)
            {
                MessageBox.Show("Микроволновая печь пуста");
                return;
            }

            if (!microwave.IsWorking)
            {
                StartMicrowave();
            }
            else
            {
                if (!microwave.IsPaused)
                    MessageBox.Show("Микроволновая печь уже запущена");

                else
                {
                    microwave.IsPaused = false;
                    StopMicrowaveButton.Content = "Пауза";
                    StartMicrowaveButton.Content = "Старт";
                }
            }
        }

        void StartMicrowave()
        {
            if (microwave.WorkTimeIsNotInstalled())
            {
                microwave.InstalledWorkTimeInSeconds = 30;
                UpdateTimeFieldWithWorkTime(microwave.InstalledWorkTimeInSeconds);
            }
            microwave.On();
            StopMicrowaveButton.Content = "Пауза";
        }

        private void StopMicrowaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!microwave.IsWorking)
            {
                if (microwave.IsWorkTimeInstalling)
                {
                    microwave.IsWorkTimeInstalling = false;
                    microwave.InstalledWorkTimeInSeconds = 0;
                    UpdateTimeFieldWithRealTime();
                }
                else
                    MessageBox.Show("Микроволновая печь уже отключена");
            }
            else
            {
                if (!microwave.IsPaused)
                {
                    microwave.IsPaused = true;
                    StopMicrowaveButton.Content = "Стоп";
                    StartMicrowaveButton.Content = "Продолжить";
                }
                else
                {
                    StopMicrowave();
                    StopMicrowaveButton.Content = "Стоп";
                    StartMicrowaveButton.Content = "Старт";
                }
            }
        }

        private void StopMicrowave()
        {
            microwave.Off();
            UpdateTimeFields();
        }

        private void CreateNewProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (!microwave.IsWorking || microwave.IsPaused)
            {
                var productType = GetProductType(sender);
                microwave.CreateNewProductAndAddInList(productType);
            }
            else
            {
                MessageBox.Show("Вы не можете добавлять в микроволновую печь новые продукты во время её работы.");
            }
        }

        private string GetProductType(object sender)
        {
            return ((Button)sender).Name.ToString();
        }

        private void OpenInfoButton_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow info = new InfoWindow();
            info.Owner = this;
            info.Show();
        }

        private void DeleteAllProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (microwave.ProductCount == 0 && table.ProductCount == 0)
            {
                MessageBox.Show("Вы не добавили ни одного продукта");
                return;
            }
            var answer = MessageBox.Show("Вы уверены, что хотите удалить все продукты?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                microwave.DeleteAllProducts();
                table.DeleteAllProducts();
                StopMicrowave();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Saver.Save();
        }

        private void SingSongButton_Click(object sender, RoutedEventArgs e)
        {
            SongsWindow songsWindow = new SongsWindow();
            songsWindow.Owner = this;
            songsWindow.Show();
        }
    }
}
