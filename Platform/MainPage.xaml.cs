using Find4;
using Game15;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Platform
{
    public sealed partial class MainPage : Page
    {
        Dictionary<string, Type> dict;
        public MainPage()
        {
            this.InitializeComponent();
            initialize();
        }

        private void initialize()
        {
            dict = new Dictionary<string, Type>();
            dict["Game15"] = typeof(game15_selection_display);
            dict["Find4"] = typeof(Find4_selection_display);
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
    }
}
