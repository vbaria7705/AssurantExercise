using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionMars.Business
{
    public class Robot : IRobot
    {
        #region Private Variables
        private int _x;
        private int _y;
        private string _direction;
        private IWorld _world;
        private bool _lost = false;
        #endregion

        #region Public Properties
        public int X {
            get { return _x; }                
        }
        public int Y
        {
            get { return _y; }
        }

        public string Direction
        {
            get { return _direction; }
        }

        public IWorld roboWorld
        {
            get
            {
                return _world;
            }

            set
            {
                _world = value;
            }
        }

        #endregion

        #region Constructors
        public Robot()
        {
            this._x = 50;
            this._y = 50;
            this._direction = "W";
        }

        public Robot(int x, int y, string direction)
        {
            this._x = x;
            this._y = y;
            this._direction = direction;
        }
        #endregion

        #region Public Methods
        public void MoveForward()
        {           
            if (this.IsLost())
                return;

            switch (this.Direction)
            {
                case "N":
                    if (this.roboWorld.UpperY == this.Y)
                        this._lost = true;                                                
                    else
                        this._y++;
                    break;
                case "E":
                    if (this.roboWorld.RightX == this.X)                        
                        this._lost = true;
                    else
                        this._x++;
                    break;
                case "S":
                    if (this.roboWorld.LowerY == this.Y)
                       this._lost = true;
                    else
                       this._y--;
                    break;
                case "W":
                    if (this.roboWorld.LeftX == this.X)
                       this._lost = true;
                    else
                       this._x--;
                    break;
                }                                    
        }

        public void TurnLeft()
        {
            switch (this.Direction)
            {
                case "N":
                    this._direction = "W";
                    break;
                case "E":
                    this._direction = "N";
                    break;
                case "S":
                    this._direction = "E";
                    break;
                case "W":
                    this._direction = "S";
                    break;
            }           
        }

        public void TurnRight()
        {
            switch (this.Direction)
            {
                case "N":
                    this._direction = "E";
                    break;
                case "E":
                    this._direction = "S";
                    break;
                case "S":
                    this._direction = "W";
                    break;
                case "W":
                    this._direction = "N";
                    break;
            }            
        }

        public void PrintCurrentPosition()
        {
            if (!this.IsLost())
            {
                Console.WriteLine("Current Position of robot:(" + this.X + "," + this.Y + ")" + this.Direction);
            }else
            {
                Console.WriteLine("Last seen position of robot:(" + this.X + "," + this.Y + ")" + this.Direction + " LOST");
            }
            
        }
        public bool IsLost()
        {
            return this._lost;
        }
        #endregion
    }
}
