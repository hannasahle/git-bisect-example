using System;
using System.Collections.Generic;
using RobotProgram.RobotLibrary;

namespace RobotProgram.RobotInAction
{
    public class RobotCommander
    {
        public static void RunRobot()
        {
            try
            {
                Console.Title = "Robot walk";

                string roomInput = WriteAndRead("Enter room size with two coordinates, example [5 9]:");
                Room room = roomInput.TranslateToRoom();

                string robotPositionInput = WriteAndRead("Enter coordinates and direction of your robot, example [5 9 North]:");
                RobotTypeVHG robotPosition = robotPositionInput.TranslateToRobot(room);

                string commandInput = WriteAndRead("Enter robot command, example [Left Right Walk Right]:");
                List<Command> commands = commandInput.TranslateToCommands();

                robotPosition.Move(commands);
                WriteAndRead("Current robot position: " + robotPosition);
            }
            catch (Exception e)
            {
                WriteAndRead("Try again: " + e.Message);
                RunRobot();
            }

        }

        private static string WriteAndRead(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
