using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Find4
{
    public sealed partial class Find4Page : Page
    {
        private bool game_over;
        private bool mute;
        private int round;
        private int cur_pos;
        private int wins;
        private int loses;
        private colors color;
        private Block option;
        private ComboBlock[] panel;

        private bool Game_Over
        {
            get
            {
                return game_over;
            }
            set
            {
                game_over = value;
                OptionVisible();
            }
        }

        public int Round
        {
            get
            {
                return round;
            }

            set
            {
                round = value;
                switch (round)
                {
                    case 0:
                        highlight6.FontWeight = FontWeights.Normal;
                        highlight1.FontWeight = FontWeights.Bold;
                        highlight6.Foreground = color.white;
                        highlight1.Foreground = color.black;
                        break;
                    case 1:
                        highlight1.FontWeight = FontWeights.Normal;
                        highlight2.FontWeight = FontWeights.Bold;
                        highlight1.Foreground = color.white;
                        highlight2.Foreground = color.black;
                        break;
                    case 2:
                        highlight2.FontWeight = FontWeights.Normal;
                        highlight3.FontWeight = FontWeights.Bold;
                        highlight2.Foreground = color.white;
                        highlight3.Foreground = color.black;
                        break;
                    case 3:
                        highlight3.FontWeight = FontWeights.Normal;
                        highlight4.FontWeight = FontWeights.Bold;
                        highlight3.Foreground = color.white;
                        highlight4.Foreground = color.black;
                        break;
                    case 4:
                        highlight4.FontWeight = FontWeights.Normal;
                        highlight5.FontWeight = FontWeights.Bold;
                        highlight4.Foreground = color.white;
                        highlight5.Foreground = color.black;
                        break;
                    case 5:
                        highlight5.FontWeight = FontWeights.Normal;
                        highlight6.FontWeight = FontWeights.Bold;
                        highlight5.Foreground = color.white;
                        highlight6.Foreground = color.black;
                        break;
                }
            }
        }

        public Find4Page()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            wins = 0;
            loses = 0;
            winscore.Text = "W:\t" + wins;
            losescore.Text = "L:\t" + loses;
            mute = false;
            color = new colors();
            option = new Block(op1, op2, op3, op4);
            panel = new ComboBlock[6];
            panel[0] = new ComboBlock(ans1_1, ans1_2, ans1_3, ans1_4, que1_1, que1_2, que1_3, que1_4);
            panel[1] = new ComboBlock(ans2_1, ans2_2, ans2_3, ans2_4, que2_1, que2_2, que2_3, que2_4);
            panel[2] = new ComboBlock(ans3_1, ans3_2, ans3_3, ans3_4, que3_1, que3_2, que3_3, que3_4);
            panel[3] = new ComboBlock(ans4_1, ans4_2, ans4_3, ans4_4, que4_1, que4_2, que4_3, que4_4);
            panel[4] = new ComboBlock(ans5_1, ans5_2, ans5_3, ans5_4, que5_1, que5_2, que5_3, que5_4);
            panel[5] = new ComboBlock(ans6_1, ans6_2, ans6_3, ans6_4, que6_1, que6_2, que6_3, que6_4);
            reset();
        }
        private void reset()
        {
            textBlock.Text = "";
            Game_Over = false;
            Round = 0;
            cur_pos = 0;
            option.randomize();
            foreach (ComboBlock c in panel)
            {
                c.ans.gray();
                c.que.gray();
            }
        }

        private void add_color(object sender, TappedRoutedEventArgs e)
        {
            if (Game_Over) return;
            Ellipse ellip = sender as Ellipse;
            if (ellip == null) return;

            But.Play();
            if (cur_pos < 3)
            {
                panel[Round].que.foo[cur_pos].Fill = ellip.Fill;
                cur_pos++;
            }
            else
            {
                panel[Round].que.foo[cur_pos].Fill = ellip.Fill;
                if (check())
                {
                    win();
                }
                cur_pos = 0;
                Round++;
            }
            if (Round == 6 && cur_pos == 0 && !Game_Over)
            {
                lose();
            }
        }

        private bool check()
        {
            List<int> listOption = new List<int> { 0, 1, 2, 3 };
            List<int> listAns = new List<int> { 0, 1, 2, 3 };
            int black = 0, white = 0;
            Color col1, col2;
            for (int i = 0; i < 4; i++)
            {
                var brush1 = option.foo[i].Fill as SolidColorBrush;
                if (brush1 != null)
                    col1 = brush1.Color;
                var brush2 = panel[Round].que.foo[i].Fill as SolidColorBrush;
                if (brush2 != null)
                    col2 = brush2.Color;

                if (col1 == col2)
                {
                    black++;
                    listOption.Remove(i);
                    listAns.Remove(i);
                }
            }

            for (int i = 0; i < listOption.Count; i++)
            {
                var brush1 = option.foo[listOption[i]].Fill as SolidColorBrush;
                if (brush1 != null)
                    col1 = brush1.Color;

                for (int k = 0; k < listAns.Count; k++)
                {
                    var brush2 = panel[Round].que.foo[listAns[k]].Fill as SolidColorBrush;
                    if (brush2 != null)
                        col2 = brush2.Color;
                    if (col1 == col2)
                    {
                        white++;
                        listAns.Remove(listAns[k]);
                        break;
                    }
                }
            }

            int j;
            for (j = 0; j < black; j++)
            {
                panel[Round].ans.foo[j].Fill = color.black;
            }
            for (int i = 0; i < white; i++)
            {
                panel[Round].ans.foo[j].Fill = color.white;
                j++;
            }

            return black == 4;
        }

        private void win()
        {
            Game_Over = true;
            Win.Play();
            wins++;
            textBlock.Text = "WINNER!!!";
            winscore.Text = "W:\t" + wins;
        }
        private void lose()
        {
            Game_Over = true;
            Lose.Play();
            loses++;
            textBlock.Text = "LOSER";
            losescore.Text = "L:\t" + loses;
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.GoBack();
            }
        }

        public void OptionVisible()
        {
            if (Game_Over)
            {
                op_text.Visibility = Visibility.Visible;
                op.Visibility = Visibility.Visible;
                undo.Opacity = 0;// Visibility = Visibility.Collapsed;
                select.Visibility = Visibility.Collapsed;
            }
            else
            {
                op_text.Visibility = Visibility.Collapsed;
                op.Visibility = Visibility.Collapsed;
                undo.Opacity = 100;// Visibility = Visibility.Visible;
                select.Visibility = Visibility.Visible;
            }
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (game_over || cur_pos == 0)
                return;

            cur_pos--;
            panel[Round].que.gray(cur_pos, cur_pos + 1);
        }

        private void Mute_Toogled(object sender, RoutedEventArgs e)
        {
            if (mute)
            {
                mute = false;
                MuteButton.Content = "🔊";
                Win.Volume = 1;
                Lose.Volume = 1;
                But.Volume = 1;
            }
            else
            {
                mute = true;
                MuteButton.Content = "🔇";
                Win.Volume = 0;
                Lose.Volume = 0;
                But.Volume = 0;
            }
        }

        private void ButtonSound(object sender, PointerRoutedEventArgs e)
        {
            But.Play();
        }
        private void ButtonStop(object sender, PointerRoutedEventArgs e)
        {
            But.Stop();
        }
    }
}
