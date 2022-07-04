using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gnop2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _animate = new DispatcherTimer();
        private double ballVelocity = 20;
        private bool directionRight = true;

        public MainWindow()
        {
            InitializeComponent();
            _animate.Interval = TimeSpan.FromMilliseconds(32);
            _animate.Tick += PositionBall;
        }

        private void PositionBall(object? sender, EventArgs e)
        {
            // get current x of ball
            var x = Canvas.GetLeft(Ball);

            // check to keep ball going in one direction
            if (directionRight) Canvas.SetLeft(Ball, x + ballVelocity);
            else Canvas.SetLeft(Ball, x - ballVelocity);

            // check to see, if ball needs to turn
            if (x >= GameArea.ActualWidth) directionRight = false;
            else if (x <= 0) directionRight = true;

        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            // toggle the game-loop
            if (_animate.IsEnabled) _animate.Stop();
            else _animate.Start();
        }
    }
}
