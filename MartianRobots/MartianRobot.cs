using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots
{
    public class MartianRobot
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public LocationOrientation LocationOrientation { get; set; }
        public bool IsLost { get; set; }
        public readonly char[] _robotInstructions;

        public MartianRobot(int positionX, int positionY, LocationOrientation locationOrientation, char[] robotInstructions)
        {
            PositionX = positionX;
            PositionY = positionY;
            LocationOrientation = locationOrientation;
            _robotInstructions = robotInstructions;
        }

        public MartianRobot ApplyInstructions()
        {
            foreach (char instruction in _robotInstructions)
            {
                if (instruction.ToString().Equals(RobotInstruction.F.ToString()))
                    MoveForward();
                else
                    Turn90Degrees((RobotInstruction)instruction);

            }
            return this;
        }

        public void Turn90Degrees(RobotInstruction instruction)
        {
            switch (LocationOrientation)
            {
                case LocationOrientation.N:
                    LocationOrientation = instruction.Equals(RobotInstruction.R) ? LocationOrientation.E : LocationOrientation.W;
                    break;
                case LocationOrientation.E:
                    LocationOrientation = instruction.Equals(RobotInstruction.R) ? LocationOrientation.S : LocationOrientation.N;
                    break;
                case LocationOrientation.S:
                    LocationOrientation = instruction.Equals(RobotInstruction.R) ? LocationOrientation.W : LocationOrientation.E;
                    break;
                case LocationOrientation.W:
                    LocationOrientation = instruction.Equals(RobotInstruction.R) ? LocationOrientation.N : LocationOrientation.S;
                    break;
                default:
                    break;
            }
        }

        public void MoveForward()
        {
            switch (LocationOrientation)
            {
                case LocationOrientation.N:
                    PositionY++;
                    break;
                case LocationOrientation.E:
                    PositionX--;
                    break;
                case LocationOrientation.S:
                    PositionY--;
                    break;
                case LocationOrientation.W:
                    PositionX++;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Lost means robot position X or position Y went outside the defined grid coorinates
        /// </summary>
        public void CheckIfRobotMovedOutsideGrid(Tuple<int, int> _gridCoordinates)
        {
            IsLost = (PositionX < 0 || PositionX >= _gridCoordinates.Item1 ||
                PositionY < 0 || PositionY >= _gridCoordinates.Item2);
        }
    }
}
