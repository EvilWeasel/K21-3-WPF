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
        private double ballVelocity = 5;
        private bool directionRight = true;
        private bool directionBottom = true;
        private bool PLUp = false;
        private bool PLDown = false;
        private bool PRUp = false;
        private bool PRDown = false;

        public MainWindow()
        {
            InitializeComponent();
            _animate.Interval = TimeSpan.FromMilliseconds(32);
            _animate.Tick += PositionBall;
            _animate.Tick += AnimatePaddles;
            _animate.Tick += CheckCollision;
        }

        private void CheckCollision(object? sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);
            var y = Canvas.GetTop(Ball);
            // Check intersection ball with left paddle and reverse the direction if true
            if (x <= LeftPaddle.Width &&
                y >= Canvas.GetTop(LeftPaddle) &&
                y + Ball.ActualHeight <= Canvas.GetTop(LeftPaddle) + LeftPaddle.ActualHeight)
            {
                directionRight = true;
            }
            // Check intersection ball with right paddle and reverse the direction if true
            if (x + Ball.Width >= GameArea.ActualWidth - (Canvas.GetRight(RightPaddle) + RightPaddle.ActualWidth) &&
                y + RightPaddle.ActualWidth >= Canvas.GetTop(RightPaddle) &&
                y + Ball.ActualHeight <= Canvas.GetTop(RightPaddle) + RightPaddle.ActualHeight)
            {
                directionRight = false;
            }

        }

        private void AnimatePaddles(object? sender, EventArgs e)
        {
            var plY = Canvas.GetTop(LeftPaddle);
            var prY = Canvas.GetTop(RightPaddle);
            #region Left Player Movement
            if (PLUp)
                if (plY > 10)
                    Canvas.SetTop(LeftPaddle, plY - 10);
                else Canvas.SetTop(LeftPaddle, 0);
            else if (PLDown)
                if (plY + LeftPaddle.ActualHeight < GameArea.ActualHeight)
                    Canvas.SetTop(LeftPaddle, plY + 10);
            #endregion            
            #region Right Player Movement
            if (PRUp)
                if (prY > 10)
                    Canvas.SetTop(RightPaddle, prY - 10);
                else Canvas.SetTop(RightPaddle, 0);
            else if (PRDown)
                if (prY + RightPaddle.ActualHeight < GameArea.ActualHeight)
                    Canvas.SetTop(RightPaddle, prY + 10);
            #endregion
        }

        private void PositionBall(object? sender, EventArgs e)
        {
            // get current x of ball
            var x = Canvas.GetLeft(Ball);
            var y = Canvas.GetTop(Ball);

            // move ball on x
            if (directionRight) Canvas.SetLeft(Ball, x + ballVelocity);
            else Canvas.SetLeft(Ball, x - ballVelocity);

            // check to see, if ball needs to turn on x axis
            if (x >= GameArea.ActualWidth - Ball.ActualWidth) directionRight = false;
            else if (x <= 0) directionRight = true;

            // move ball on y

            if (directionBottom) Canvas.SetTop(Ball, y + ballVelocity);
            else Canvas.SetTop(Ball, y - ballVelocity);

            // check to see, if ball needs to turn on y axis
            if (y >= GameArea.ActualHeight - Ball.ActualHeight) directionBottom = false;
            else if (y <= 0) directionRight = true;
        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            // toggle the game-loop
            if (_animate.IsEnabled) _animate.Stop();
            else _animate.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void Init()
        {
            // set position of right paddle
            Canvas.SetLeft(RightPaddle, GameArea.ActualWidth - RightPaddle.ActualWidth);
            Canvas.SetTop(RightPaddle, (GameArea.ActualHeight - RightPaddle.ActualHeight) / 2);
            // set position of left paddle
            Canvas.SetLeft(LeftPaddle, 0);
            Canvas.SetTop(LeftPaddle, (GameArea.ActualHeight - LeftPaddle.ActualHeight) / 2);
            // set position of ball
            Canvas.SetLeft(Ball, (GameArea.ActualWidth - Ball.ActualWidth) / 2);
            Canvas.SetTop(Ball, (GameArea.ActualWidth - Ball.ActualWidth) / 2);
        }



        #region KeyboardEvents for Movement
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    PLUp = true;
                    PLDown = false;
                    break;
                case Key.S:
                    PLDown = true;
                    PLUp = false;
                    break;
                case Key.Up:
                    PRUp = true;
                    PRDown = false;
                    break;
                case Key.Down:
                    PRDown = true;
                    PRUp = false;
                    break;
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    PLUp = false;
                    PLDown = false;
                    break;
                case Key.S:
                    PLDown = false;
                    PLUp = false;
                    break;
                case Key.Up:
                    PRUp = false;
                    PRDown = false;
                    break;
                case Key.Down:
                    PRDown = false;
                    PRUp = false;
                    break;
            }
        }
        #endregion
    }
}
