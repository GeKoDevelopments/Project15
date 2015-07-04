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

namespace Game15
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
            image[1] = "/Icons/1.png";
            image[2] = "/Icons/2.png";
            image[3] = "/Icons/3.png";
            image[4] = "/Icons/4.png";
            image[5] = "/Icons/5.png";
            image[6] = "/Icons/6.png";
            image[7] = "/Icons/7.png";
            image[8] = "/Icons/8.png";
            image[9] = "/Icons/9.png";
            image[10] = "/Icons/10.png";
            image[11] = "/Icons/11.png";
            image[12] = "/Icons/12.png";
            image[13] = "/Icons/13.png";
            image[14] = "/Icons/14.png";
            image[15] = "/Icons/15.png";

            panel = new Tile[4][];
            for (int i = 0; i < 4; i++)
            {
                panel[i] = new Tile[4];
            }

            panel[0][0] = new Tile(image[1], image1);
            panel[0][1] = new Tile(image[2], image2);
            panel[0][2] = new Tile(image[3], image3);
            panel[0][3] = new Tile(image[4], image4);
            panel[1][0] = new Tile(image[5], image5);
            panel[1][1] = new Tile(image[6], image6);
            panel[1][2] = new Tile(image[7], image7);
            panel[1][3] = new Tile(image[8], image8);
            panel[2][0] = new Tile(image[9], image9);
            panel[2][1] = new Tile(image[10], image10);
            panel[2][2] = new Tile(image[11], image11);
            panel[2][3] = new Tile(image[12], image12);
            panel[3][0] = new Tile(image[13], image13);
            panel[3][1] = new Tile(image[14], image14);
            panel[3][2] = new Tile(image[15], image15);
            panel[3][3] = new Tile("", image16);
        }

        Point empty = new Point(3, 3);
        Random rnd = new Random();
        int difficulty = 15;
        int counter = 0;

        void swap_empty(Point a)
        {
            string temp = panel[(int)a.X][(int)a.Y].n;
            panel[(int)a.X][(int)a.Y].n = panel[(int)empty.X][(int)empty.Y].n;
            panel[(int)empty.X][(int)empty.Y].n = temp;
            empty = a;
        }

        private void move(object sender, TappedRoutedEventArgs e)
        {
            Image im = (Image)sender;
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

            counter++;
            textBlock.Text = "Clicks: " + counter;

            image1.Source = new BitmapImage(new Uri(base.BaseUri, panel[0][0].n));
            image2.Source = new BitmapImage(new Uri(base.BaseUri, panel[0][1].n));
            image3.Source = new BitmapImage(new Uri(base.BaseUri, panel[0][2].n));
            image4.Source = new BitmapImage(new Uri(base.BaseUri, panel[0][3].n));
            image5.Source = new BitmapImage(new Uri(base.BaseUri, panel[1][0].n));
            image6.Source = new BitmapImage(new Uri(base.BaseUri, panel[1][1].n));
            image7.Source = new BitmapImage(new Uri(base.BaseUri, panel[1][2].n));
            image8.Source = new BitmapImage(new Uri(base.BaseUri, panel[1][3].n));
            image9.Source = new BitmapImage(new Uri(base.BaseUri, panel[2][0].n));
            image10.Source = new BitmapImage(new Uri(base.BaseUri, panel[2][1].n));
            image11.Source = new BitmapImage(new Uri(base.BaseUri, panel[2][2].n));
            image12.Source = new BitmapImage(new Uri(base.BaseUri, panel[2][3].n));
            image13.Source = new BitmapImage(new Uri(base.BaseUri, panel[3][0].n));
            image14.Source = new BitmapImage(new Uri(base.BaseUri, panel[3][1].n));
            image15.Source = new BitmapImage(new Uri(base.BaseUri, panel[3][2].n));
            image16.Source = new BitmapImage(new Uri(base.BaseUri, panel[3][3].n));

            if (check_win() == true)
                button.Visibility = Visibility.Visible;
        }

        private void Shuffle(object sender, RoutedEventArgs e)
        {
            button.Visibility = Visibility.Collapsed;
            for (int i = 0; i < difficulty; i++)
            {
                Tile y;
                int x = rnd.Next() % 3;
                if (x >= empty.Y)
                    x++;

                y = panel[(int)empty.X][x];
                move(y.i, new TappedRoutedEventArgs());

                x = rnd.Next() % 3;
                if (x >= empty.Y)
                    x++;

                y = panel[x][(int)empty.Y];
                move(y.i, new TappedRoutedEventArgs());
            }
            counter = 0;
            textBlock.Text = "Clicks: " + counter;
        }

        private Boolean check_win()
        {
            if (panel[3][3].n != "")
                return false;

            return (
            panel[0][0].n == image[1]
            && panel[0][1].n == image[2]
            && panel[0][2].n == image[3]
            && panel[0][3].n == image[4]
            && panel[1][0].n == image[5]
            && panel[1][1].n == image[6]
            && panel[1][2].n == image[7]
            && panel[1][3].n == image[8]
            && panel[2][0].n == image[9]
            && panel[2][1].n == image[10]
            && panel[2][2].n == image[11]
            && panel[2][3].n == image[12]
            && panel[3][0].n == image[13]
            && panel[3][1].n == image[14]
            && panel[3][2].n == image[15]
       );
        }
    }

    public class Tile
    {
        public string n { get; set; }
        public Image i { get; }
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

    }
}
