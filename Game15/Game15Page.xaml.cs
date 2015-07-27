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
        int difficulty;
        int counter;
        bool game_over;
        bool shuffle;

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
                    ShuffleButton.Visibility = Visibility.Visible;
                    win_text.Visibility = Visibility.Visible;
                    panel[empty.pos()].set_visible(true);
                    //im16.Opacity = 100;
                }
                else
                {
                    ShuffleButton.Visibility = Visibility.Collapsed;
                    win_text.Visibility = Visibility.Collapsed;
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
            difficulty = 15;
            counter = 0;
            game_over = true;
            shuffle = false;

            empty = new Point(3, 3);
            string folder;
            folder = "mickey";
            
            panel = new Tile[16];

            pan = new Dictionary<Image, Tile>();
            panel[0] = new Tile(im1, folder, 1);
            panel[1] = new Tile(im2, folder, 2);
            panel[2] = new Tile(im3, folder, 3);
            panel[3] = new Tile(im4, folder, 4);
            panel[4] = new Tile(im5, folder, 5);
            panel[5] = new Tile(im6, folder, 6);
            panel[6] = new Tile(im7, folder, 7);
            panel[7] = new Tile(im8, folder, 8);
            panel[8] = new Tile(im9, folder, 9);
            panel[9] = new Tile(im10, folder, 10);
            panel[10] = new Tile(im11, folder, 11);
            panel[11] = new Tile(im12, folder, 12);
            panel[12] = new Tile(im13, folder, 13);
            panel[13] = new Tile(im14, folder, 14);
            panel[14] = new Tile(im15, folder, 15);
            panel[15] = new Tile(im16, folder, 16);
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
            panel[empty.pos()].set_visible(false);
        }

        void swap_empty(Point p)
        {
            int a = p.pos();
            int b = empty.pos();
            int i = panel[a].n;
            panel[a].n = panel[b].n;
            panel[b].n = i;
            panel[a].update();
            panel[b].update();
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
            ShuffleButton.Visibility = Visibility.Collapsed;
            while (check_win() == true)
            {
                for (int i = 0; i < difficulty; i++)
                {
                    int r = rnd.Next() % 3;
                    if (r >= empty.Y)
                        r++;

                    x = new Point(empty.X, r);
                    y = panel[x.pos()];
                    move(y.i, null);

                    r = rnd.Next() % 3;
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
            if (panel[15].n != 16)
                return false;

            return (panel[0].n == 1
                 && panel[1].n == 2
                 && panel[2].n == 3
                 && panel[3].n == 4
                 && panel[4].n == 5
                 && panel[5].n == 6
                 && panel[6].n == 7
                 && panel[7].n == 8
                 && panel[8].n == 9
                 && panel[9].n == 10
                 && panel[10].n == 11
                 && panel[11].n == 12
                 && panel[12].n == 13
                 && panel[13].n == 14
                 && panel[14].n == 15
            );
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.GoBack();
            }
        }
    }
}
