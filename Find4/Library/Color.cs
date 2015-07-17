using Windows.UI.Xaml.Media;

namespace Find4
{
    public class colors
    {
        public SolidColorBrush red { get; }
        public SolidColorBrush orange { get; }
        public SolidColorBrush violet { get; }
        public SolidColorBrush indigo { get; }
        public SolidColorBrush blue { get; }
        public SolidColorBrush green { get; }
        public SolidColorBrush white { get; }
        public SolidColorBrush black { get; }
        public SolidColorBrush gray { get; }

        public colors()
        {
            red = new SolidColorBrush();
            orange = new SolidColorBrush();
            violet = new SolidColorBrush();
            indigo = new SolidColorBrush();
            blue = new SolidColorBrush();
            green = new SolidColorBrush();
            white = new SolidColorBrush();
            black = new SolidColorBrush();
            gray = new SolidColorBrush();

            red.Color = Windows.UI.Color.FromArgb(255, 255, 0, 0);
            orange.Color = Windows.UI.Color.FromArgb(255, 255, 165, 0);
            violet.Color = Windows.UI.Color.FromArgb(255, 238, 130, 238);
            indigo.Color = Windows.UI.Color.FromArgb(255, 75, 0, 130);
            blue.Color = Windows.UI.Color.FromArgb(255, 0, 0, 255);
            green.Color = Windows.UI.Color.FromArgb(255, 0, 128, 0);
            white.Color = Windows.UI.Color.FromArgb(255, 255, 255, 255);
            black.Color = Windows.UI.Color.FromArgb(255, 0, 0, 0);
            gray.Color = Windows.UI.Color.FromArgb(255, 128, 128, 128);
        }
    }

}
