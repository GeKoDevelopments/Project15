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
using System.Resources;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Game15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Game15Page : Page
    {
        public Tile[][] panel;
        string[] text;
        Point empty;
        Random rnd;
        int difficulty;
        int counter;

        public Game15Page()
        {
            this.InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            rnd = new Random();
            difficulty = 15;
            counter = 0;

            empty = new Point(3, 3);

            text = new string[16];
            text[0] = "";
            text[1] = "1";
            text[2] = "2";
            text[3] = "3";
            text[4] = "4";
            text[5] = "5";
            text[6] = "6";
            text[7] = "7";
            text[8] = "8";
            text[9] = "9";
            text[10] = "10";
            text[11] = "11";
            text[12] = "12";
            text[13] = "13";
            text[14] = "14";
            text[15] = "15";

            panel = new Tile[4][];
            for (int i = 0; i < 4; i++)
            {
                panel[i] = new Tile[4];
            }

            panel[0][0] = new Tile(gr1, text[1]);
            panel[0][1] = new Tile(gr2, text[2]);
            panel[0][2] = new Tile(gr3, text[3]);
            panel[0][3] = new Tile(gr4, text[4]);
            panel[1][0] = new Tile(gr5, text[5]);
            panel[1][1] = new Tile(gr6, text[6]);
            panel[1][2] = new Tile(gr7, text[7]);
            panel[1][3] = new Tile(gr8, text[8]);
            panel[2][0] = new Tile(gr9, text[9]);
            panel[2][1] = new Tile(gr10, text[10]);
            panel[2][2] = new Tile(gr11, text[11]);
            panel[2][3] = new Tile(gr12, text[12]);
            panel[3][0] = new Tile(gr13, text[13]);
            panel[3][1] = new Tile(gr14, text[14]);
            panel[3][2] = new Tile(gr15, text[15]);
            panel[3][3] = new Tile(gr16, text[0]);
        }

        void swap_empty(Point a)
        {
            string temp = panel[a.X][a.Y].t;
            panel[a.X][a.Y].t = panel[empty.X][empty.Y].t;
            panel[empty.X][empty.Y].t = temp;
            empty = a;
        }

        private void move(object sender, TappedRoutedEventArgs e)
        {
            ((Rectangle)panel[empty.X][empty.Y].n.Children[0]).Visibility = Visibility.Visible;
            Grid gr = (Grid)sender;
            Point pos = null;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (panel[i][j].check_text(gr))
                        pos = new Point(i, j);

            if (pos.X == empty.X)
            {
                if (pos.Y < empty.Y)
                {
                    while (pos.Y < empty.Y)
                        swap_empty(new Point(empty.X, empty.Y - 1));
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
                        swap_empty(new Point(empty.X - 1, empty.Y));
                }
                else
                {
                    while (pos.X > empty.X)
                        swap_empty(new Point(empty.X + 1, empty.Y));
                }
            }

            counter++;
            textBlock.Text = "Clicks: " + counter;

            ((TextBlock)gr1.Children[1]).Text = panel[0][0].t;
            ((TextBlock)gr2.Children[1]).Text = panel[0][1].t;
            ((TextBlock)gr3.Children[1]).Text = panel[0][2].t;
            ((TextBlock)gr4.Children[1]).Text = panel[0][3].t;
            ((TextBlock)gr5.Children[1]).Text = panel[1][0].t;
            ((TextBlock)gr6.Children[1]).Text = panel[1][1].t;
            ((TextBlock)gr7.Children[1]).Text = panel[1][2].t;
            ((TextBlock)gr8.Children[1]).Text = panel[1][3].t;
            ((TextBlock)gr9.Children[1]).Text = panel[2][0].t;
            ((TextBlock)gr10.Children[1]).Text = panel[2][1].t;
            ((TextBlock)gr11.Children[1]).Text = panel[2][2].t;
            ((TextBlock)gr12.Children[1]).Text = panel[2][3].t;
            ((TextBlock)gr13.Children[1]).Text = panel[3][0].t;
            ((TextBlock)gr14.Children[1]).Text = panel[3][1].t;
            ((TextBlock)gr15.Children[1]).Text = panel[3][2].t;
            ((TextBlock)gr16.Children[1]).Text = panel[3][3].t;

            if (check_win() == true)
                button.Visibility = Visibility.Visible;

            ((Rectangle)panel[empty.X][empty.Y].n.Children[0]).Visibility = Visibility.Collapsed;
        }

        private void Shuffle(object sender, RoutedEventArgs e)
        {
            Tile y;
            button.Visibility = Visibility.Collapsed;
            for (int i = 0; i < difficulty; i++)
            {
                int x = rnd.Next() % 3;
                if (x >= empty.Y)
                    x++;

                y = panel[empty.X][x];
                move(y.n, null);

                x = rnd.Next() % 3;
                if (x >= empty.Y)
                    x++;

                y = panel[x][empty.Y];
                move(y.n, null);
            }
            if (empty.X != 3)
            {
                y = panel[3][empty.Y];
                move(y.n, null);
            }
            if (empty.Y != 3)
            {
                y = panel[empty.X][3];
                move(y.n, null);
            }
            counter = 0;
            textBlock.Text = "Clicks: " + counter;
        }

        private Boolean check_win()
        {
            if (((TextBlock)panel[3][3].n.Children[1]).Text != text[0])
                return false;

            return (
            ((TextBlock)panel[0][0].n.Children[1]).Text == text[1]
            && ((TextBlock)panel[0][1].n.Children[1]).Text == text[2]
            && ((TextBlock)panel[0][2].n.Children[1]).Text == text[3]
            && ((TextBlock)panel[0][3].n.Children[1]).Text == text[4]
            && ((TextBlock)panel[1][0].n.Children[1]).Text == text[5]
            && ((TextBlock)panel[1][1].n.Children[1]).Text == text[6]
            && ((TextBlock)panel[1][2].n.Children[1]).Text == text[7]
            && ((TextBlock)panel[1][3].n.Children[1]).Text == text[8]
            && ((TextBlock)panel[2][0].n.Children[1]).Text == text[9]
            && ((TextBlock)panel[2][1].n.Children[1]).Text == text[10]
            && ((TextBlock)panel[2][2].n.Children[1]).Text == text[11]
            && ((TextBlock)panel[2][3].n.Children[1]).Text == text[12]
            && ((TextBlock)panel[3][0].n.Children[1]).Text == text[13]
            && ((TextBlock)panel[3][1].n.Children[1]).Text == text[14]
            && ((TextBlock)panel[3][2].n.Children[1]).Text == text[15]
            );
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y) { X = x; Y = y; }
    }

    public class Tile
    {
        public Grid n { get; }
        public string t { get; set; }
        public Tile(Grid gr, string nu)
        {
            n = gr;
            t = nu;
        }
        public bool check_text(Grid im)
        {
            return n == im;
        }
    }
}
