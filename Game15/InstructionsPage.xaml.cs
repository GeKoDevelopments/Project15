using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Game15
{
    public sealed partial class InstructionsPage : Page
    {
        public InstructionsPage()
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
