using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace JamieTheRobot2
{
    public enum RobotDirection
    {
        N,
        S,
        E,
        W
    }

    public class Robot
    {
        public RobotDirection Direction;

        private int X;
        private int Y;
        const int MaxRange = 100;

        public event EventHandler Crash;

        public Robot()
        {
            this.X = 0;
            this.Y = 0;
            this.Direction = RobotDirection.N;
        }

        public Point Position => new Point(X, Y);

        public void Go(int distance)
        {
            switch (this.Direction)
            {
                case RobotDirection.N:
                    Y += distance;
                    if (Y > MaxRange)
                    {
                        Y = MaxRange;
                        Crash(this, EventArgs.Empty);
                    }
                    break;
                case RobotDirection.S:
                    Y -= distance;
                    if (Y < -MaxRange)
                    {
                        Y = -MaxRange;
                        Crash(this, EventArgs.Empty);
                    }
                    break;
                case RobotDirection.W:
                    X -= distance;
                    if (X < -MaxRange)
                    {
                        X = -MaxRange;
                        Crash(this, EventArgs.Empty);
                    }
                    break;
                case RobotDirection.E:
                    X += distance;
                    if (X > MaxRange)
                    {
                        X = MaxRange;
                        Crash(this, EventArgs.Empty);
                    }
                    break;
            }
        }
    }
}
