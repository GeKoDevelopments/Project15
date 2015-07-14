using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Platform
{
    public sealed partial class CreditsPage : Page
    {
        public CreditsPage()
        {
            this.InitializeComponent();
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
