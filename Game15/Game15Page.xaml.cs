using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace Game15
{
    public sealed partial class Game15Page : Page
    {
        Tile[] panel;
        Dictionary<Image, Tile> pan;
        Point empty;
        Random rnd;
        string folder;
        int difficulty;
        int counter;
        bool game_over;
        bool shuffle;

        void BorderVisible(int i)
        {
            b1.BorderThickness = new Thickness(i);
            b2.BorderThickness = new Thickness(i);
            b3.BorderThickness = new Thickness(i);
            b4.BorderThickness = new Thickness(i);
            b5.BorderThickness = new Thickness(i);
            b6.BorderThickness = new Thickness(i);
            b7.BorderThickness = new Thickness(i);
            b8.BorderThickness = new Thickness(i);
            b9.BorderThickness = new Thickness(i);
            b10.BorderThickness = new Thickness(i);
            b11.BorderThickness = new Thickness(i);
            b12.BorderThickness = new Thickness(i);
            b13.BorderThickness = new Thickness(i);
            b14.BorderThickness = new Thickness(i);
            b15.BorderThickness = new Thickness(i);
            b16.BorderThickness = new Thickness(i);
        }

        public bool Game_over
        {
            get
            {
                return game_over;
            }

            set
            {
                game_over = value;
                if (game_over == true)
                {
                    BorderVisible(0);
                    options.Visibility = Visibility.Visible;
                    win_text.Visibility = Visibility.Visible;
                    panel[empty.pos()].set_visible(true);
                    //im16.Opacity = 100;
                }
                else
                {
                    BorderVisible(1);
                    counter = 0;
                    textBlock.Text = "Clicks: " + counter;
                    options.Visibility = Visibility.Collapsed;
                    win_text.Visibility = Visibility.Collapsed;
                    panel[empty.pos()].set_visible(false);
                }
            }
        }

        public Game15Page()
        {
            this.InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            rnd = new Random();
            empty = new Point(3, 3);
            difficulty = 15;
            shuffle = false;

            panel = new Tile[16];

            pan = new Dictionary<Image, Tile>();
            panel[0] = new Tile(im1, 1);
            panel[1] = new Tile(im2, 2);
            panel[2] = new Tile(im3, 3);
            panel[3] = new Tile(im4, 4);
            panel[4] = new Tile(im5, 5);
            panel[5] = new Tile(im6, 6);
            panel[6] = new Tile(im7, 7);
            panel[7] = new Tile(im8, 8);
            panel[8] = new Tile(im9, 9);
            panel[9] = new Tile(im10, 10);
            panel[10] = new Tile(im11, 11);
            panel[11] = new Tile(im12, 12);
            panel[12] = new Tile(im13, 13);
            panel[13] = new Tile(im14, 14);
            panel[14] = new Tile(im15, 15);
            panel[15] = new Tile(im16, 16);
            pan[im1] = panel[0];
            pan[im2] = panel[1];
            pan[im3] = panel[2];
            pan[im4] = panel[3];
            pan[im5] = panel[4];
            pan[im6] = panel[5];
            pan[im7] = panel[6];
            pan[im8] = panel[7];
            pan[im9] = panel[8];
            pan[im10] = panel[9];
            pan[im11] = panel[10];
            pan[im12] = panel[11];
            pan[im13] = panel[12];
            pan[im14] = panel[13];
            pan[im15] = panel[14];
            pan[im16] = panel[15];

            Game_over = true;
            win_text.Visibility = Visibility.Collapsed;

            folder = "numbers";
            foreach (Tile m in panel)
                m.update(folder);
        }

        void swap_empty(Point p)
        {
            int a = p.pos();
            int b = empty.pos();
            int i = panel[a].n;
            panel[a].n = panel[b].n;
            panel[b].n = i;
            panel[a].update(folder);
            panel[b].update(folder);
            empty = p;
        }

        private void move(object sender, TappedRoutedEventArgs e)
        {
            if (Game_over) return;

            Image im = (Image)sender;
            Point pos = null;
            Tile t = pan[im];
            pos = t.pos;

            if ((pos.X != empty.X) ^ (pos.Y == empty.Y)) return;

            if (!shuffle)
            {
                slide.Stop();
                slide.Play();
            }

            panel[empty.pos()].set_visible(true);
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
            panel[empty.pos()].set_visible(false);

            if (!shuffle)
            {
                counter++;
                textBlock.Text = "Clicks: " + counter;

                if (check_win() == true)
                {
                    Game_over = true;
                }
            }
        }

        private void Shuffle(object sender, RoutedEventArgs e)
        {
            Tile y;
            Point x;
            Game_over = false;
            shuffle = true;
            while (check_win() == true)
            {
                for (int i = 0; i < difficulty; i++)
                {
                    int r = rnd.Next(3);
                    if (r >= empty.Y)
                        r++;

                    x = new Point(empty.X, r);
                    y = panel[x.pos()];
                    move(y.i, null);

                    r = rnd.Next(3);
                    if (r >= empty.Y)
                        r++;

                    x = new Point(r, empty.Y);
                    y = panel[x.pos()];
                    move(y.i, null);
                }
                if (empty.X != 3)
                {
                    x = new Point(3, empty.Y);
                    y = panel[x.pos()];
                    move(y.i, null);
                }
                if (empty.Y != 3)
                {
                    x = new Point(empty.X, 3);
                    y = panel[x.pos()];
                    move(y.i, null);
                }
            }
            shuffle = false;
        }

        private Boolean check_win()
        {
            if (panel[15].check() == false)
                return false;

            foreach (Tile t in panel)
                if (t.check() == false)
                    return false;

            return true;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.GoBack();
            }
        }

        private void Selected(object sender, TappedRoutedEventArgs e)
        {
            string path = ((BitmapImage)((Image)sender).Source).UriSource.ToString();
            string[] s = path.Split('/');
            folder = s[3];

            foreach (Tile m in panel)
                m.update(folder);
        }
    }
}
