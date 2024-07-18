using System.Windows;
using System.Windows.Threading;

namespace BookManagement_NguyenDucHuan
{
    /// <summary>
    /// Interaction logic for AutoCloseMessage.xaml
    /// </summary>
    public partial class AutoCloseMessage : Window
    {
        private DispatcherTimer _timer;
        public AutoCloseMessage(string message, int displayDurationInSeconds)
        {

            InitializeComponent();
            MessageTextBlock.Text = message;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(displayDurationInSeconds)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            this.Close();
        }
    }
}
