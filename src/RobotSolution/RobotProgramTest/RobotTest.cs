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
            var robot = new RobotTypeVHG(new Room(5, 5), 1, 2, Direction.North);
            var commands = new List<Command> { Command.Right, Command.Walk, Command.Right, Command.Walk, Command.Walk, Command.Right, Command.Walk, Command.Right, Command.Walk };
            robot.Move(commands);  
            Assert.AreEqual(robot.Coordinates.X, 1);
            Assert.AreEqual(robot.Coordinates.Y, 3);  
            Assert.AreEqual(robot.CurrentDirection, Direction.North);
        }  

        [TestMethod]
        public void WalkTest2()
        {
            var robot = new RobotTypeVHG(new Room(5, 5), 0, 0, Direction.East);
            var commands = new List<Command> { Command.Right, Command.Walk, Command.Left, Command.Walk, Command.Walk, Command.Left, Command.Right, Command.Walk };
            robot.Move(commands);
            Assert.AreEqual(robot.Coordinates.X, 3);
            Assert.AreEqual(robot.Coordinates.Y, 1);
            Assert.AreEqual(robot.CurrentDirection, Direction.East);    
        }  

        [TestMethod]
        public void WalkOutOfBoundTest1()
        {
            try
            {
                var robot = new RobotTypeVHG(new Room(5, 5), 5, 5, Direction.East);
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
                var robot = new RobotTypeVHG(new Room(5, 5), 4, 4, Direction.South);
                var commands = new List<Command> { Command.Walk, Command.Walk, Command.Walk };
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
