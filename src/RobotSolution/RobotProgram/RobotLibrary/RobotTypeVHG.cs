using System.Collections.Generic;


namespace RobotProgram.RobotLibrary
{
    public class RobotTypeVHG : Robot
    {
        public RobotTypeVHG(Room room, int xStartPosition, int yStartPosition, Direction direction) :
            base(room, xStartPosition, yStartPosition, direction)
        {
        }

        public override void Move(List<Command> commands)
        {
            foreach (Command c in commands)
            {
                switch (c)
                {
                    case Command.V:
                        TurnLeft();
                        break;
                    case Command.H:
                        TurnRight();
                        break;
                    case Command.G:
                        WalkStraight();
                        break;
                }
            }
        }
    }
}
