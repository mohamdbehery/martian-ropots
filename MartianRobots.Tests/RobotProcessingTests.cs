using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MartianRobots.Tests
{
    [TestClass]
    public class RobotProcessingTests
    {
        private readonly RobotProcessing _robotProcessing; // system under testing
        public RobotProcessingTests()
        {
            _robotProcessing = new RobotProcessing(3, 5);
        }

        [DataRow("1 1 E", "RFRFRFRF", 1, 1, LocationOrientation.E, false)]
        [DataRow("3 2 N", "FRRFLLFFRRFLL", 3, 3, LocationOrientation.N, true)]
        [DataRow("0 3 W", "LLFFFLFLFL", -2, 4, LocationOrientation.S, true)]
        [TestMethod]
        public void ProcessSingleRobot_DefaultScenario(string robotPosition, string instructions, int positionX,
            int positionY, LocationOrientation locationOrientation, bool isLost)
        {
            MartianRobot martianRobot = _robotProcessing.ProcessSingleRobot(new KeyValuePair<string, string>(robotPosition, instructions));
            Assert.IsNotNull(martianRobot);
            Assert.AreEqual(martianRobot.PositionX, positionX);
            Assert.AreEqual(martianRobot.PositionY, positionY);
            Assert.AreEqual(martianRobot.LocationOrientation, locationOrientation);
            Assert.AreEqual(martianRobot.IsLost, isLost);
        }

        [DataRow(3, 5, true)]
        [DataRow(-1, 5, false)]
        [DataRow(1, -5, false)]
        [DataRow(51, 5, false)]
        [DataRow(3, 60, false)]
        [TestMethod]
        public void IsValidCoordinates_Default(int cordX, int cordY, bool isValid)
        {
            bool actualIsValid = _robotProcessing.IsValidCoordinates(new Tuple<int, int>(cordX, cordY));
            Assert.AreEqual(isValid, actualIsValid);
        }

        [DataRow("1 1 E", "RFRFRFRF", true)]
        [DataRow("0 3 W", "HLFTFLFLFL", false)]
        [DataRow("0 60 W", "FRRFLLFFRRFLL", false)]
        [TestMethod]
        public void IsValidRobotData(string position, string instructions, bool isValid)
        {
            bool actualIsValid = _robotProcessing.IsValidRobotData(new KeyValuePair<string, string>(position, instructions));
            Assert.AreEqual(isValid, actualIsValid);
        }
    }
}
