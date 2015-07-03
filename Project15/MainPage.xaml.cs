using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Project15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Tile[][] panel;
        string[] image = new string[16];
        public MainPage()
        {
            this.InitializeComponent();

            image[0] = "";
            image[1] = "/Assets/1.png";
            image[2] = "/Assets/2.png";
            image[3] = "/Assets/3.png";
            image[4] = "/Assets/4.png";
            image[5] = "/Assets/5.png";
            image[6] = "/Assets/6.png";
            image[7] = "/Assets/7.png";
            image[8] = "/Assets/8.png";
            image[9] = "/Assets/9.png";
            image[10] = "/Assets/10.png";
            image[11] = "/Assets/11.png";
            image[12] = "/Assets/12.png";
            image[13] = "/Assets/13.png";
            image[14] = "/Assets/14.png";
            image[15] = "/Assets/15.png";

            panel = new Tile[4][];
            for (int i = 0; i < 4; i++)
            {
                panel[i] = new Tile[4];
            }

            panel[0][0] = new Tile("/Assets/1.png", image1);
            panel[0][1] = new Tile("/Assets/2.png", image2);
            panel[0][2] = new Tile("/Assets/3.png", image3);
            panel[0][3] = new Tile("/Assets/4.png", image4);
            panel[1][0] = new Tile("/Assets/5.png", image5);
            panel[1][1] = new Tile("/Assets/6.png", image6);
            panel[1][2] = new Tile("/Assets/7.png", image7);
            panel[1][3] = new Tile("/Assets/8.png", image8);
            panel[2][0] = new Tile("/Assets/9.png", image9);
            panel[2][1] = new Tile("/Assets/10.png", image10);
            panel[2][2] = new Tile("/Assets/11.png", image11);
            panel[2][3] = new Tile("/Assets/12.png", image12);
            panel[3][0] = new Tile("/Assets/13.png", image13);
            panel[3][1] = new Tile("/Assets/14.png", image14);
            panel[3][2] = new Tile("/Assets/15.png", image15);
            panel[3][3] = new Tile("", image16);
        }

        Point empty = new Point(3, 3);
        void swap_empty(Point a)
        {
            string temp = panel[(int) a.X][(int) a.Y].getnum();
            panel[(int)a.X][(int)a.Y].swap(panel[(int)empty.X][(int)empty.Y].getnum());
            panel[(int)empty.X][(int)empty.Y].swap(temp);
            empty = a;
        }

        private void move(object sender, TappedRoutedEventArgs e)
        {
            Image im = (Image) sender;
            Point pos;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (panel[i][j].check_image(im))
                    {
                        pos = new Point(i, j);
                        break;
                    }
            if (pos.X == empty.X)
            {
                if (pos.Y < empty.Y)
                {
                    while (pos.Y < empty.Y)
                    {
                        swap_empty(new Point(empty.X, empty.Y - 1));
                    }
                }
                else
                {
                    while (pos.Y > empty.Y)
                        swap_empty(new Point(empty.X, empty.Y + 1));
                }
            }
            else if (pos.Y == empty.Y)
            {
                if (pos.X < empty.X)
                {
                    while (pos.X < empty.X)
                    {
                        swap_empty(new Point(empty.X - 1, empty.Y));
                    }
                }
                else
                {
                    while (pos.X > empty.X)
                        swap_empty(new Point(empty.X + 1, empty.Y));
                }
            }

            image1.Source = new BitmapImage(new Uri(base.BaseUri, panel[0][0].getnum()));
            image2.Source = new BitmapImage(new Uri(base.BaseUri, panel[0][1].getnum()));
            image3.Source = new BitmapImage(new Uri(base.BaseUri, panel[0][2].getnum()));
            image4.Source = new BitmapImage(new Uri(base.BaseUri, panel[0][3].getnum()));
            image5.Source = new BitmapImage(new Uri(base.BaseUri, panel[1][0].getnum()));
            image6.Source = new BitmapImage(new Uri(base.BaseUri, panel[1][1].getnum()));
            image7.Source = new BitmapImage(new Uri(base.BaseUri, panel[1][2].getnum()));
            image8.Source = new BitmapImage(new Uri(base.BaseUri, panel[1][3].getnum()));
            image9.Source = new BitmapImage(new Uri(base.BaseUri, panel[2][0].getnum()));
            image10.Source = new BitmapImage(new Uri(base.BaseUri, panel[2][1].getnum()));
            image11.Source = new BitmapImage(new Uri(base.BaseUri, panel[2][2].getnum()));
            image12.Source = new BitmapImage(new Uri(base.BaseUri, panel[2][3].getnum()));
            image13.Source = new BitmapImage(new Uri(base.BaseUri, panel[3][0].getnum()));
            image14.Source = new BitmapImage(new Uri(base.BaseUri, panel[3][1].getnum()));
            image15.Source = new BitmapImage(new Uri(base.BaseUri, panel[3][2].getnum()));
            image16.Source = new BitmapImage(new Uri(base.BaseUri, panel[3][3].getnum()));
            /*
            Thickness f = g.Margin;
            f.Left = 0;
            f.Right = 0;
            f.Top = 0;
            f.Bottom = 0;
            g.Margin = f;
            */
            /*
            string str = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    str += panel[i][j].getnum().ToString();
                str += "\n";
            }
            textBox.Text = str;
            */
        }

    }

    public class Tile
    {
        string n;
        Image i;
        public Tile(string nu, Image im)
        {
            n = nu;
            i = im;
        }
        public bool check_image(Image im)
        {
            return i == im;
        }
        public string getnum()
        {
            return n;
        }
        public void swap(string nu)
        {
            n = nu;
        }
    } 
}
