using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using XamlGeneratedNamespace;

namespace Pong2.ViewModels
{
    internal class GameViewModel
    {
        private bool P1Up = false;
        private bool P1Down = false;
        private bool P2Up = false;
        private bool P2Down = false;

        // timer
        private DispatcherTimer PlayerTimer = new DispatcherTimer();
        private DispatcherTimer AnimTimer = new DispatcherTimer();

        // ball speed
        private double SpeedX;
        private double SpeedY;

        // player score
        private int ScorePlayer1;
        private int ScorePlayer2;

        public GameViewModel()
        {
            Init();
        }

        private void Init()
        {
            // core controls
            P1Up = false;
            P1Down = false;
            P2Up = false;   
            P2Down = false;
            // initial ball-speed => will increase over time
            SpeedX = 100;
            SpeedY = 100;

            // timer for player movement
            PlayerTimer.Interval = TimeSpan.FromMilliseconds(30);
            PlayerTimer.Tick += MovePlayer;
            PlayerTimer.Start();

            // timer for ball animation
            AnimTimer.Interval = TimeSpan.FromSeconds(0.05);
            AnimTimer.Tick += Animate;
            AnimTimer.Start();
        }

        private void Animate(object? sender, EventArgs e)
        {
            var x = Canvas.GetLeft(Ball);
        }

        private void MovePlayer(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    enum Difficulty
    {
        Easy,
        Hard,
        Russian
    }
}
