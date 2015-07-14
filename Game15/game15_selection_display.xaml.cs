using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Game15
{
    public sealed partial class game15_selection_display : Page
    {
        Dictionary<string, Type> dict;
        public game15_selection_display()
        {
            this.InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            dict = new Dictionary<string, Type>();
            dict["Play"] = typeof(Game15Page);
            dict["Instructions"] = typeof(InstructionsPage);
            dict["Credits"] = typeof(CreditsPage);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string s = b.Name;
            if (this.Frame != null)
            {
                this.Frame.Navigate(dict[s]);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null)
            {
                this.Frame.GoBack();
            }
        }
    }
}
