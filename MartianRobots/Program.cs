using System;
using System.Collections.Generic;

namespace MartianRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the grid cordinates numbers (separaed by space between)");
            string gridCoordsString = Console.ReadLine();
            if (gridCoordsString.Split(" ").Length == 2 &&
                int.TryParse(gridCoordsString.Split(" ")[0], out int gridCordsX) &&
                int.TryParse(gridCoordsString.Split(" ")[1], out int gridCordsY))
            {
                Console.WriteLine("Now please enter the number of robots");
                if (int.TryParse(Console.ReadLine(), out int numberOfRobots))
                {
                    var inputRobots = new Dictionary<string, string>();
                    while (numberOfRobots > 0)
                    {
                        Console.WriteLine("Now please enter robot position => PositionX PositionY Orientation (separaed by space between)");
                        string robotPositionString = Console.ReadLine();
                        Console.WriteLine("Now please enter instructions");
                        string robotInstructionsString = Console.ReadLine();
                        inputRobots.Add(robotPositionString, robotInstructionsString);
                        numberOfRobots--;
                    }
                    Console.WriteLine("----------------------------------------------");
                    RobotProcessing robotProcessing = new RobotProcessing(gridCordsX, gridCordsY);
                    robotProcessing.ProcessRobots(inputRobots);
                }
                Console.ReadLine();
            }
            else
                Console.WriteLine("Invalid grid coordinates");
        }
    }
}
