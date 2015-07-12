using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace Game15
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y) { X = x; Y = y; }
    }

    public class Tile
    {
        public Grid g { get; }
        private Rectangle r;
        private TextBlock t;
        public Tile(Grid gr, Rectangle re, TextBlock te, string nu)
        {
            g = gr;
            r = re;
            t = te;
            t.Text = nu;
        }
        public void set_text(string te)
        {
            t.Text = te;
        }
        public string get_text()
        {
            return t.Text;
        }
        public void set_visible(bool b)
        {
            if (b)
                r.Visibility = Visibility.Visible;
            else
                r.Visibility = Visibility.Collapsed;
        }
    }
}
