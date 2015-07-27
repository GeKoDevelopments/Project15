using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace Game15
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y) { X = x; Y = y; }
        internal int pos()
        {
            return 4 * X + Y;
        }
    }

    public class Tile
    {
        public Image i;
        private string folder;
        public Point pos { get; }
        public int n { get; set; }
        public Tile(Image im, string p, int nu)
        {
            i = im;
            n = nu;
            nu--;
            pos = new Point(nu / 4, nu % 4);
            folder = p;
            string path = "ms-appx:/Game15/img/" + folder + "/" + n + ".jpg";
            i.Source = new BitmapImage(new Uri(path));
        }
        public void set_visible(bool b)
        {
            if (b)
                i.Opacity = 100;
            else
                i.Opacity = 0;
        }

        internal BitmapImage get_source()
        {
            return (BitmapImage) i.Source;
        }

        internal void set_source(BitmapImage v)
        {
            i.Source = v;
        }

        internal void update()
        {
            string path = "ms-appx:/Game15/img/" + folder + "/" + n + ".jpg";
            i.Source = new BitmapImage(new Uri(path));
        }
    }
}
