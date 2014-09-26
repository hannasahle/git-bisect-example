using System;
using System.Collections.Generic;
using System.Globalization;
using RobotProgram.RobotLibrary;

namespace RobotProgram.RobotInAction
{
    public static class Translation
    {
        public static Room TranslateToRoom(this string inputString)
        {
            string[] splitRoom = inputString.Split(' ');

            if (splitRoom.Length == 2)
            {
                int width;
                int depth;

                if (Int32.TryParse(splitRoom[0], out width) &&
                    Int32.TryParse(splitRoom[1], out depth))
                    return new Room(width, depth);
            }
            throw new Exception("Storlek på rummet har felaktigt format.");
        }

        public static RobotTypeVHG TranslateToRobot(this string inputString, Room room)
        {
            string[] splitPosition = inputString.Split(' ');

            if (splitPosition.Length == 3)
            {
                int xPosition;
                int yPosition;
                Direction direction;

                if (Int32.TryParse(splitPosition[0], out xPosition) &&
                    Int32.TryParse(splitPosition[1], out yPosition) &&
                    Enum.TryParse(splitPosition[2], out direction))
                    return new RobotTypeVHG(room, xPosition, yPosition, direction);
            }
            throw new Exception("Robot positionering har felaktigt format.");
        }

        public static List<Command> TranslateToCommands(this string inputString)
        {
            var commands = new List<Command>();

            foreach (char txt in inputString)
            {
                Command enumValue;
                if (!Enum.TryParse(txt.ToString(CultureInfo.InvariantCulture), out enumValue))
                    throw new Exception(txt + " är ett otillåtet kommando.");

                commands.Add(enumValue);
            }
            return commands;
        }
    }
}
