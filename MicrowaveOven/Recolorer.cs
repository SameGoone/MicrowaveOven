using System.Windows.Controls;
using System.Windows.Media;

namespace MicrowaveOven
{
    public class Recolorer
    {
        private TextBlock minuteTextBlock;
        private TextBlock secondsTextBlock;
        private TextBlock colonTextBlock;
        public Recolorer(TextBlock minuteTextBlock, TextBlock secondsTextBlock, TextBlock colonTextBlock)
        {
            this.minuteTextBlock = minuteTextBlock;
            this.secondsTextBlock = secondsTextBlock;
            this.colonTextBlock = colonTextBlock;
        }

        public void RecolorTimeTextBlocks(SolidColorBrush brush)
        {
            minuteTextBlock.Foreground = brush;
            secondsTextBlock.Foreground = brush;
            colonTextBlock.Foreground = brush;
        }
    }
}
