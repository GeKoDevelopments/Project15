using System.Collections.Generic;
using Windows.UI;
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
        private int round;
        private int cur_pos;
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
                OptionVisible(game_over);
            }
        }

        public Find4Page()
        {
            InitializeComponent();
            initialize();
        }

        private void initialize()
        {
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
            round = 0;
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
            if (cur_pos < 3)
            {
                if (ellip != null)
                {
                    panel[round].que.foo[cur_pos].Fill = ellip.Fill;

                }
                cur_pos++;
            }
            else
            {
                if (ellip != null)
                {
                    panel[round].que.foo[cur_pos].Fill = ellip.Fill;

                }
                if (check())
                {
                    win();
                }
                cur_pos = 0;
                round++;
            }
            if (round == 6 && cur_pos == 0 && !Game_Over)
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
                var brush2 = panel[round].que.foo[i].Fill as SolidColorBrush;
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
                    var brush2 = panel[round].que.foo[listAns[k]].Fill as SolidColorBrush;
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
                panel[round].ans.foo[j].Fill = color.black;
            }
            for (int i = 0; i < white; i++)
            {
                panel[round].ans.foo[j].Fill = color.white;
                j++;
            }

            return black == 4;
        }

        private void win()
        {
            Game_Over = true;
            textBlock.Text = "WINNER";
        }
        private void lose()
        {
            Game_Over = true;
            textBlock.Text = "LOSER";
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

        public void OptionVisible(bool b)
        {
            if (b)
                op.Visibility = Visibility.Visible;
            else
                op.Visibility = Visibility.Collapsed;
        }

    }
}
