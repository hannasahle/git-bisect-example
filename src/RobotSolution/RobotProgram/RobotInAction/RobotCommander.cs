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
                Console.Title = "Robotprogrammering";

                string roomInput = WriteAndRead("Storlek på rummet med två koordinater, exempel [5 9]:");
                Room room = roomInput.TranslateToRoom();

                string robotPositionInput = WriteAndRead("Koordinater och riktning på din robot, exempel [5 9 N]:");
                RobotTypeVHG robotPosition = robotPositionInput.TranslateToRobot(room);

                string commandInput = WriteAndRead("Styrkommando (V = vänster, H = höger, G = framåt), exempel [VHGGG]:");
                List<Command> commands = commandInput.TranslateToCommands();

                robotPosition.Move(commands);
                WriteAndRead("Rapport: " + robotPosition);
            }
            catch (Exception e)
            {
                WriteAndRead("Försök igen: " + e.Message);
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
