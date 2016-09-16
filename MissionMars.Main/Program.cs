using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissionMars.Business;

namespace MissionMars.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            //using List to store and retrieve data in-memory.
            IList<IRobot> robotCollection = new List<IRobot>();
            int counter = 1;
            string line;

            IWorld world = CreateWorld();
            while (true)
            {
                Console.WriteLine("Send robot # " + counter.ToString() + " to Mars?[Y/N]");                
                if ((line = Console.ReadLine()).ToUpper() == "Y")
                {                 
                    IRobot robot = CreateRobot();
                    robot.roboWorld = world;                    

                    Console.WriteLine("Enter moving instruction:");
                    line = Console.ReadLine().ToUpper();
                    while (line.Length >= 100)
                    {
                        Console.WriteLine("Moving instraction must be less than 100 characters long.");
                        Console.WriteLine("Please enter valid moving instruction:");
                        line = Console.ReadLine().ToUpper();
                    }                   
                    char[] charArray = line.ToCharArray();
                    foreach (char c in charArray)
                    {
                        switch (c.ToString())
                        {
                            case "L":
                                robot.TurnLeft();                                
                                break;
                            case "R":
                                robot.TurnRight();                                
                                break;
                            case "F":
                                var col = from r in robotCollection
                                          where r.X == robot.X && r.Y == robot.Y
                                          select r;
                                                                
                                if (col.Count() != 0)
                                {
                                    switch (robot.Direction)
                                    {
                                        case "N":
                                            if ((robot.Y + 1) > robot.roboWorld.UpperY)
                                            {
                                                //dont' move
                                            }
                                            else
                                            {
                                                robot.MoveForward();
                                            }
                                            break;
                                        case "E":
                                            if ((robot.X + 1) > robot.roboWorld.RightX)
                                            {
                                                //dont' move
                                            }
                                            else
                                            {
                                                robot.MoveForward();
                                            }
                                            break;
                                        case "S":
                                            if ((robot.Y - 1) < robot.roboWorld.UpperY)
                                            {
                                                //dont' move
                                            }
                                            else
                                            {
                                                robot.MoveForward();
                                            }
                                            break;
                                        case "W":
                                            if ((robot.X - 1) < robot.roboWorld.LeftX)
                                            {
                                                //dont' move
                                            }
                                            else
                                            {
                                                robot.MoveForward();
                                            }
                                            break;
                                    }
                                }
                                else
                                {
                                    robot.MoveForward();
                                }                               
                                break;
                        }                  
                    }
                    robot.PrintCurrentPosition();
                    if (robot.IsLost())
                        robotCollection.Add(robot);
                    counter++;
                    Console.WriteLine("============================================================");
                }
            }           
        }

        public static World CreateWorld()
        {
            int val1, val2;
            Console.WriteLine("Enter upper-right coordinates of the rectangular world:");
            var rect = Console.ReadLine().Split(' ');
            while (rect.Length != 2 || !(int.TryParse(rect[0], out val1)) || !(int.TryParse(rect[1], out val2)) || val1 > 50 || val2 > 50)
            {
                Console.WriteLine("Invalid coordinates!");
                Console.WriteLine("Enter upper-right coordinates of the rectangular world:");
                rect = Console.ReadLine().Split(' ');
            }
            return new World(val1, val2);
        }

        public static Robot CreateRobot()
        {
            int val1, val2;
            string[] dir = { "N", "E", "W", "S" };
            Console.WriteLine("Enter initial position of the robot:");
            var pos = Console.ReadLine().ToUpper().Split(' ');
            while (pos.Length != 3 || !(int.TryParse(pos[0], out val1)) || !(int.TryParse(pos[1], out val2)) || val1 > 50 || val2 > 50 || !dir.Contains(pos[2]))
            {
                Console.WriteLine("Invalid position!");
                Console.WriteLine("Enter initial position of the robot:");
                pos = Console.ReadLine().ToUpper().Split(' ');
            }
            return new Robot(val1, val2, pos[2]);
        }
    }
}
