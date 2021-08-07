using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Tests
{
    [TestClass]
    public class MartianRobotTests
    {
        [DataRow(RobotInstruction.L, LocationOrientation.N, LocationOrientation.W)]
        [DataRow(RobotInstruction.R, LocationOrientation.N, LocationOrientation.E)]
        [DataRow(RobotInstruction.L, LocationOrientation.E, LocationOrientation.N)]
        [DataRow(RobotInstruction.R, LocationOrientation.E, LocationOrientation.S)]
        [DataRow(RobotInstruction.L, LocationOrientation.S, LocationOrientation.E)]
        [DataRow(RobotInstruction.R, LocationOrientation.S, LocationOrientation.W)]
        [DataRow(RobotInstruction.L, LocationOrientation.W, LocationOrientation.S)]
        [DataRow(RobotInstruction.R, LocationOrientation.W, LocationOrientation.N)]
        [TestMethod]
        public void Turn90Degrees_Default(RobotInstruction robotInstruction, LocationOrientation currentOrientation, LocationOrientation expectedOrientation)
        {
            MartianRobot martianRobot = new MartianRobot(1, 1, currentOrientation, new char[] { 'L' });
            martianRobot.Turn90Degrees(robotInstruction);
            Assert.AreEqual(martianRobot.LocationOrientation, expectedOrientation);
        }

        [DataRow(3, 2, LocationOrientation.N, 3, 3)]
        [DataRow(5, 7, LocationOrientation.E, 4, 7)]
        [DataRow(1, 2, LocationOrientation.S, 1, 1)]
        [DataRow(4, 3, LocationOrientation.W, 5, 3)]
        [TestMethod]
        public void MoveForward_Default(int positionX, int positionY, LocationOrientation orientation, int expetedPositionX, int expetedPositionY)
        {
            MartianRobot martianRobot = new MartianRobot(positionX, positionY, orientation, new char[] { 'F' });
            martianRobot.MoveForward();
            Assert.AreEqual(martianRobot.PositionX, expetedPositionX);
            Assert.AreEqual(martianRobot.PositionY, expetedPositionY);
        }

        [DataRow(3, 2, LocationOrientation.N, false)]
        [DataRow(5, 7, LocationOrientation.E, true)]
        [DataRow(1, 2, LocationOrientation.S, false)]
        [DataRow(4, 3, LocationOrientation.W, false)]
        [TestMethod]
        public void CheckIfRobotMovedOutsideGrid_Default(int positionX, int positionY, LocationOrientation orientation, bool isLost)
        {
            MartianRobot martianRobot = new MartianRobot(positionX, positionY, orientation, new char[] { 'F' });
            martianRobot.CheckIfRobotMovedOutsideGrid(new Tuple<int, int>(7, 5));
            Assert.AreEqual(martianRobot.IsLost, isLost);
        }
    }
}
