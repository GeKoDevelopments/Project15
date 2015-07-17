using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Game15
{
    public sealed partial class Game15Page : Page
    {
        Tile[][] panel;
        string[] text;
        Point empty;
        Random rnd;
        int difficulty;
        int counter;
        bool game_over;

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
                    shuffle.Visibility = Visibility.Visible;
                    win_text.Visibility = Visibility.Visible;
                }
                else
                {
                    shuffle.Visibility = Visibility.Collapsed;
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

            panel[0][0] = new Tile(gr1, rec1, tex1, text[1]);
            panel[0][1] = new Tile(gr2, rec2, tex2, text[2]);
            panel[0][2] = new Tile(gr3, rec3, tex3, text[3]);
            panel[0][3] = new Tile(gr4, rec4, tex4, text[4]);
            panel[1][0] = new Tile(gr5, rec5, tex5, text[5]);
            panel[1][1] = new Tile(gr6, rec6, tex6, text[6]);
            panel[1][2] = new Tile(gr7, rec7, tex7, text[7]);
            panel[1][3] = new Tile(gr8, rec8, tex8, text[8]);
            panel[2][0] = new Tile(gr9, rec9, tex9, text[9]);
            panel[2][1] = new Tile(gr10, rec10, tex10, text[10]);
            panel[2][2] = new Tile(gr11, rec11, tex11, text[11]);
            panel[2][3] = new Tile(gr12, rec12, tex12, text[12]);
            panel[3][0] = new Tile(gr13, rec13, tex13, text[13]);
            panel[3][1] = new Tile(gr14, rec14, tex14, text[14]);
            panel[3][2] = new Tile(gr15, rec15, tex15, text[15]);
            panel[3][3] = new Tile(gr16, rec16, tex16, text[0]);
        }

        void swap_empty(Point a)
        {
            string temp = panel[a.X][a.Y].get_text();
            panel[a.X][a.Y].set_text(panel[empty.X][empty.Y].get_text());
            panel[empty.X][empty.Y].set_text(temp);
            empty = a;
        }

        private void move(object sender, TappedRoutedEventArgs e)
        {
            if (Game_over) return;

            Grid gr = (Grid)sender;
            Point pos = null;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (panel[i][j].g == gr)
                        pos = new Point(i, j);

            if ((pos.X != empty.X) ^ (pos.Y == empty.Y)) return;

            panel[empty.X][empty.Y].set_visible(true);
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

            if (check_win() == true)
            {
                Game_over = true;
            }

            panel[empty.X][empty.Y].set_visible(false);
        }

        private void Shuffle(object sender, RoutedEventArgs e)
        {
            Tile y;
            Game_over = false;
            shuffle.Visibility = Visibility.Collapsed;
            while (check_win() == true)
            {
                for (int i = 0; i < difficulty; i++)
                {
                    int x = rnd.Next() % 3;
                    if (x >= empty.Y)
                        x++;

                    y = panel[empty.X][x];
                    move(y.g, null);

                    x = rnd.Next() % 3;
                    if (x >= empty.Y)
                        x++;

                    y = panel[x][empty.Y];
                    move(y.g, null);
                }
                if (empty.X != 3)
                {
                    y = panel[3][empty.Y];
                    move(y.g, null);
                }
                if (empty.Y != 3)
                {
                    y = panel[empty.X][3];
                    move(y.g, null);
                }
            }
            counter = 0;
            textBlock.Text = "Clicks: " + counter;
        }

        private Boolean check_win()
        {
            if (panel[3][3].get_text() != text[0])
                return false;

            return (panel[0][0].get_text() == text[1]
            && panel[0][1].get_text() == text[2]
            && panel[0][2].get_text() == text[3]
            && panel[0][3].get_text() == text[4]
            && panel[1][0].get_text() == text[5]
            && panel[1][1].get_text() == text[6]
            && panel[1][2].get_text() == text[7]
            && panel[1][3].get_text() == text[8]
            && panel[2][0].get_text() == text[9]
            && panel[2][1].get_text() == text[10]
            && panel[2][2].get_text() == text[11]
            && panel[2][3].get_text() == text[12]
            && panel[3][0].get_text() == text[13]
            && panel[3][1].get_text() == text[14]
            && panel[3][2].get_text() == text[15]
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
