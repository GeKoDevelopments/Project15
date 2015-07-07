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
        Block[] panel;
        public Find4Page()
        {
            this.InitializeComponent();
            initialize();
        }

        public void initialize()
        {
            round = 0;
            cur_pos = 0;
            color = new colors();
            panel = new Block[6];
            panel[0] = new Block(ans1_1, ans1_2, ans1_3, ans1_4, que1_1, que1_2, que1_3, que1_4);
            panel[1] = new Block(ans2_1, ans2_2, ans2_3, ans2_4, que2_1, que2_2, que2_3, que2_4);
            panel[2] = new Block(ans3_1, ans3_2, ans3_3, ans3_4, que3_1, que3_2, que3_3, que3_4);
            panel[3] = new Block(ans4_1, ans4_2, ans4_3, ans4_4, que4_1, que4_2, que4_3, que4_4);
            panel[4] = new Block(ans5_1, ans5_2, ans5_3, ans5_4, que5_1, que5_2, que5_3, que5_4);
            panel[5] = new Block(ans6_1, ans6_2, ans6_3, ans6_4, que6_1, que6_2, que6_3, que6_4);
        }

        private void add_color(object sender, TappedRoutedEventArgs e)
        {

            cur_pos++;
            if (cur_pos == 4)
                check();
        }

        private void check()
        {
            throw new NotImplementedException();
        }
    }

    public class Block
    {
        public Ellipse[] ans { get; set; }
        public Ellipse[] que { get; set; }
        public Block(Ellipse a1, Ellipse a2, Ellipse a3, Ellipse a4,
            Ellipse q1, Ellipse q2, Ellipse q3, Ellipse q4)
        {
            colors color = new colors();
            ans = new Ellipse[4];
            ans[0] = a1;
            ans[1] = a2;
            ans[2] = a3;
            ans[3] = a4;
            a1.Fill = color.gray;
            a2.Fill = color.gray;
            a3.Fill = color.gray;
            a4.Fill = color.gray;
            que = new Ellipse[4];
            que[0] = q1;
            que[1] = q2;
            que[2] = q3;
            que[3] = q4;
            q1.Fill = color.gray;
            q2.Fill = color.gray;
            q3.Fill = color.gray;
            q4.Fill = color.gray;
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
}
