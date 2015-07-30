using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

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
        public Point pos { get; }
        public int n { get; set; }
        public Tile(Image im, int nu)
        {
            i = im;
            n = nu;
            nu--;
            pos = new Point(nu / 4, nu % 4);
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

        internal void update(string folder)
        {
            string path = "ms-appx:/Game15/img/" + folder + "/" + n + ".jpg";
            i.Source = new BitmapImage(new Uri(path));
        }
    }
}
