using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionMars.Business
{
    public interface IRobot
    {
        #region Properties       
        int X { get; }
        int Y { get; }
        string Direction { get; }
        IWorld roboWorld { get; set; }
        #endregion

        #region Methods
        void TurnLeft();
        void TurnRight();
        void MoveForward();
        void PrintCurrentPosition();
        bool IsLost();
        #endregion

    }
}
