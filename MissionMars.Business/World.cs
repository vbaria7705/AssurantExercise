using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionMars.Business
{
    public class World:IWorld
    {
        #region Public Properties
        public int RightX { get; set; }
        public int UpperY { get; set; }
        public int LeftX { get; set; }
        public int LowerY { get; set; }
        #endregion

        #region Constructors
        public World()
        {
            this.LowerY = 0;
            this.LeftX = 0;
            this.RightX = 50;
            this.UpperY = 50;
        }

        public World(int x,int y)
        {
            this.RightX = x;
            this.UpperY = y;
            this.LeftX = 0;
            this.LowerY = 0;
        }
        #endregion
    }
}
