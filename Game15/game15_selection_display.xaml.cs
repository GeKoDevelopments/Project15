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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Game15
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class game15_selection_display : Page
    {
        public game15_selection_display()
        {
            this.InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string s = b.Name;
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(Game15Page));
            }
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string s = b.Name;
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(InstructionsPage));
            }
        }

        private void Credits_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            string s = b.Name;
            if (this.Frame != null)
            {
                this.Frame.Navigate(typeof(CreditsPage));
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
