using System.ComponentModel;

namespace RobotProgram.RobotLibrary
{
    public class Room
    {
        public readonly int Width;
        public readonly int Depth;

        public Room(int width, int depth)
        {
            Width = width;
            Depth = depth;
        }
    }

    public struct Coordinates
    {
        public int X;
        public int Y;

        public Coordinates(int xPosition, int yPosition)
        {
            X = xPosition;
            Y = yPosition;
        }
    }

    public enum Command
    {
        [Description("Turn Left")]
        V,
        [Description("Turn Right")]
        H,
        [Description("Go Straight")]
        G
    };

    public enum Direction
    {
        [Description("East")]
        Ö,
        [Description("South")]
        S,
        [Description("West")]
        V,
        [Description("North")]
        N
    };

}
