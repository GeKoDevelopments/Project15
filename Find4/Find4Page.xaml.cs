using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Find4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Find4Page : Page
    {
        int round;
        int cur_pos;
        colors color;
        Block option;
        ComboBlock[] panel;
        bool game_over;

        public Find4Page()
        {
            this.InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            textBlock.Text = "";
            game_over = false;
            round = 0;
            cur_pos = 0;
            color = new colors();
            option = new Block(op1, op2, op3, op4);
            panel = new ComboBlock[6];
            panel[0] = new ComboBlock(ans1_1, ans1_2, ans1_3, ans1_4, que1_1, que1_2, que1_3, que1_4);
            panel[1] = new ComboBlock(ans2_1, ans2_2, ans2_3, ans2_4, que2_1, que2_2, que2_3, que2_4);
            panel[2] = new ComboBlock(ans3_1, ans3_2, ans3_3, ans3_4, que3_1, que3_2, que3_3, que3_4);
            panel[3] = new ComboBlock(ans4_1, ans4_2, ans4_3, ans4_4, que4_1, que4_2, que4_3, que4_4);
            panel[4] = new ComboBlock(ans5_1, ans5_2, ans5_3, ans5_4, que5_1, que5_2, que5_3, que5_4);
            panel[5] = new ComboBlock(ans6_1, ans6_2, ans6_3, ans6_4, que6_1, que6_2, que6_3, que6_4);

        }

        private void add_color(object sender, TappedRoutedEventArgs e)
        {
            if (game_over) return;

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
            if (round == 6 && cur_pos == 0)
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


        /* OI win kai lose einai proxires...vlepoume ti tha kanoume */
        private void win()
        {
            game_over = true;
            textBlock.Text = "WINNER";
        }
        private void lose()
        {
            game_over = true;
            textBlock.Text = "LOSER";
        }


        public class Block
        {
            public Ellipse[] foo { get; set; }
            public Block(Ellipse q1, Ellipse q2, Ellipse q3, Ellipse q4)
            {
                foo = new Ellipse[4];
                foo[0] = q1;
                foo[1] = q2;
                foo[2] = q3;
                foo[3] = q4;
            }

            public void randomize()
            {
                colors col = new colors();
                Random rand = new Random();
                for (int i = 0; i < 4; i++)
                {
                    int option = rand.Next(1, 7);
                    switch (option)
                    {
                        case 1:
                            foo[i].Fill = col.red;
                            break;
                        case 2:
                            foo[i].Fill = col.orange;
                            break;
                        case 3:
                            foo[i].Fill = col.indigo;
                            break;
                        case 4:
                            foo[i].Fill = col.yellow;
                            break;
                        case 5:
                            foo[i].Fill = col.blue;
                            break;
                        case 6:
                            foo[i].Fill = col.green;
                            break;
                    }
                }
            }
            public void gray()
            {
                colors col = new colors();
                for (int i = 0; i < 4; i++)
                {
                    foo[i].Fill = col.gray;
                }
            }
        }
        public class ComboBlock
        {
            public Block ans { get; set; }
            public Block que { get; set; }

            public ComboBlock(Ellipse a1, Ellipse a2, Ellipse a3, Ellipse a4,
                Ellipse q1, Ellipse q2, Ellipse q3, Ellipse q4)
            {
                que = new Block(q1, q2, q3, q4);
                ans = new Block(a1, a2, a3, a4);
                que.gray();
                ans.gray();
            }
        }
        public class colors
        {
            public SolidColorBrush red { get; }
            public SolidColorBrush orange { get; }
            public SolidColorBrush yellow { get; }
            public SolidColorBrush indigo { get; }
            public SolidColorBrush blue { get; }
            public SolidColorBrush green { get; }
            public SolidColorBrush white { get; }
            public SolidColorBrush black { get; }
            public SolidColorBrush gray { get; }

            public colors()
            {
                red = new SolidColorBrush();
                orange = new SolidColorBrush();
                yellow = new SolidColorBrush();
                indigo = new SolidColorBrush();
                blue = new SolidColorBrush();
                green = new SolidColorBrush();
                white = new SolidColorBrush();
                black = new SolidColorBrush();
                gray = new SolidColorBrush();

                red.Color = Windows.UI.Color.FromArgb(255, 255, 0, 0);
                orange.Color = Windows.UI.Color.FromArgb(255, 255, 165, 0);
                yellow.Color = Windows.UI.Color.FromArgb(255, 255, 255, 0);
                indigo.Color = Windows.UI.Color.FromArgb(255, 75, 0, 130);
                blue.Color = Windows.UI.Color.FromArgb(255, 0, 128, 0);
                green.Color = Windows.UI.Color.FromArgb(255, 255, 0, 0);
                white.Color = Windows.UI.Color.FromArgb(255, 255, 255, 255);
                black.Color = Windows.UI.Color.FromArgb(255, 0, 0, 0);
                gray.Color = Windows.UI.Color.FromArgb(255, 128, 128, 128);
            }
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.GoBack();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            initialize();
        }
    }
}
