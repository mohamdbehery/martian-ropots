using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots
{
    public class RobotProcessing
    {
        private readonly Tuple<int, int> _gridCoordinates;
        public RobotProcessing(int gridLatitude, int gridLongtude)
        {
            _gridCoordinates = new Tuple<int, int>(gridLatitude, gridLongtude);
        }

        /// <summary>
        /// generate the grid, using a 2D array
        /// for each robot in the input list
        ///     set robot location in the grid
        ///     foreach instruction
        ///         move\turn robot & check if robot moved outside the legal area
        /// return last position and check if lost
        /// </summary>
        public void ProcessRobots(Dictionary<string, string> inputRobots)
        {
            if (IsValidCoordinates(_gridCoordinates))
            {
                foreach (var inputRobot in inputRobots)
                {
                    MartianRobot robot = ProcessSingleRobot(inputRobot);
                    if (robot == null)
                        Console.WriteLine($"Robot[{inputRobot.Key}] has invalid input data");
                    else
                        Console.WriteLine($"{robot.PositionX} {robot.PositionY} {robot.LocationOrientation.ToString()} " +
                            $"{(robot.IsLost ? "LOST" : string.Empty)}");
                }
            }
            else
                Console.WriteLine("Invalid coordinates");
        }

        public MartianRobot ProcessSingleRobot(KeyValuePair<string, string> inputRobot)
        {
            string position = inputRobot.Key;
            string instructions = inputRobot.Value;
            MartianRobot robot = null;
            if (IsValidRobotData(inputRobot))
            {
                robot = new MartianRobot(
                    int.Parse(position.Split(" ")[0]),
                    int.Parse(position.Split(" ")[1]),
                    (LocationOrientation)Enum.Parse(typeof(LocationOrientation), position.Split(" ")[2]),
                    instructions.ToCharArray());

                robot.ApplyInstructions().CheckIfRobotMovedOutsideGrid(_gridCoordinates);
            }
            return robot;
        }

        public bool IsValidCoordinates(Tuple<int, int> _gridCoordinates)
        {
            return (_gridCoordinates.Item1 >= 0 && _gridCoordinates.Item1 <= 50 &&
                _gridCoordinates.Item2 >= 0 && _gridCoordinates.Item2 <= 50);
        }

        public bool IsValidRobotData(KeyValuePair<string, string> robotString)
        {
            return (// validate position
                robotString.Key.Split(" ").Length == 3 &&
                int.Parse(robotString.Key.Split(" ")[0]) <= 50 &&
                int.Parse(robotString.Key.Split(" ")[1]) <= 50 &&
                Enum.IsDefined(typeof(LocationOrientation), robotString.Key.Split(" ")[2]) &&
                // validate instructions
                robotString.Value.Length > 0 &&
                robotString.Value.ToCharArray().Count(
                    instruction => Enum.IsDefined(typeof(RobotInstruction), instruction.ToString())
                ) == robotString.Value.ToCharArray().Length); // if all instructions are defined in instructions enum            
        }
    }
}
