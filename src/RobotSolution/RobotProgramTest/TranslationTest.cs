using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotProgram.RobotInAction;
using RobotProgram.RobotLibrary;

namespace RobotProgramTest
{
    [TestClass]
    public class TranslationTest
    {
        [TestMethod]
        public void TranslateToRoomTest()
        {
            {
                const string input = "4 5";
                Room goodRoom = input.TranslateToRoom();
                Assert.AreEqual(goodRoom.Width, 4);
                Assert.AreEqual(goodRoom.Depth, 5);
            }

            {
                var strangeInputs = new[] { "3", "T O", "3 4 5" };
                foreach (string input in strangeInputs)
                {
                    try
                    {
                        input.TranslateToRoom();
                    }
                    catch
                    {
                        continue;
                    }
                    Assert.AreEqual(1, 2);
                }
            }
        }

        [TestMethod]
        public void TranslateToRobotTest()
        {
            var room = new Room(5, 7);
            {
                const string input = "4 5 N";
                RobotTypeVHG goodRobot = input.TranslateToRobot(room);
                Assert.AreEqual(goodRobot.Coordinates.X, 4);
                Assert.AreEqual(goodRobot.Coordinates.Y, 5);
                Assert.AreEqual(goodRobot.CurrentDirection, Direction.N);
            }

            {
                var strangeInputs = new[] { "3 4 s", "5 7 N", "3 5", "4 4 FF" };
                foreach (string input in strangeInputs)
                {
                    try
                    {
                        input.TranslateToRobot(room);
                    }
                    catch
                    {
                        continue;
                    }
                    Assert.AreEqual(1, 2);
                }
            }
        }

        [TestMethod]
        public void TranslateToCommandsTest()
        {
            {
                const string input = "HGHHVVG";
                List<Command> goodCommands = input.TranslateToCommands();
                var facitCommands = new List<Command> { Command.H, Command.G, Command.H, Command.H, Command.V, Command.V, Command.G };
                Assert.AreEqual(goodCommands.Count, facitCommands.Count);
                for (int i = 0; i < goodCommands.Count; i++)
                {
                    Assert.AreEqual(goodCommands[i], facitCommands[i]);
                }

            }

            {
                var strangeInputs = new[] { "3 4 s", "HGsHVVG", "HGH HVVG" };
                foreach (string input in strangeInputs)
                {
                    try
                    {
                        input.TranslateToCommands();
                    }
                    catch
                    {
                        continue;
                    }
                    Assert.AreEqual(1, 2);
                }
            }
        }
    }
}
