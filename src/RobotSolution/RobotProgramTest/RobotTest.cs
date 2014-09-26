using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotProgram.RobotLibrary;

namespace RobotProgramTest
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        public void WalkTest1()
        {
            var robot = new RobotTypeVHG(new Room(5, 5), 1, 2, Direction.N);
            var commands = new List<Command> { Command.H, Command.G, Command.H, Command.G, Command.G, Command.H, Command.G, Command.H, Command.G };
            robot.Move(commands);
            Assert.AreEqual(robot.Coordinates.X, 1);
            Assert.AreEqual(robot.Coordinates.Y, 3);
            Assert.AreEqual(robot.CurrentDirection, Direction.N);
        }

        [TestMethod]
        public void WalkTest2()
        {
            var robot = new RobotTypeVHG(new Room(5, 5), 0, 0, Direction.Ö);
            var commands = new List<Command> { Command.H, Command.G, Command.V, Command.G, Command.G, Command.V, Command.H, Command.G };
            robot.Move(commands);
            Assert.AreEqual(robot.Coordinates.X, 3);
            Assert.AreEqual(robot.Coordinates.Y, 1);
            Assert.AreEqual(robot.CurrentDirection, Direction.Ö);
        }

        [TestMethod]
        public void WalkOutOfBoundTest1()
        {
            try
            {
                var robot = new RobotTypeVHG(new Room(5, 5), 5, 5, Direction.Ö);
            }
            catch
            {
                return;
            }
            Assert.AreEqual(1, 2);
        }

        [TestMethod]
        public void WalkOutOfBoundTest2()
        {
            try
            {
                var robot = new RobotTypeVHG(new Room(5, 5), 4, 4, Direction.S);
                var commands = new List<Command> { Command.G, Command.G, Command.G };
                robot.Move(commands);
            }
            catch
            {
                return;
            }
            Assert.AreEqual(1, 2);
        }
    }
}
