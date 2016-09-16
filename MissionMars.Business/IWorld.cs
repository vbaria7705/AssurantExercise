using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionMars.Business
{
    public interface IWorld
    {
        int RightX { get; set; }
        int UpperY { get; set; }
        int LeftX { get; set; }
        int LowerY { get; set; }
    }
}
