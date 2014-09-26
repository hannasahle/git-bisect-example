using System;
using System.Collections.Generic;

namespace RobotProgram.RobotLibrary
{
    public abstract class Robot
    {
        public Room Room { get; private set; }
        public Direction CurrentDirection { get; private set; }

        private Coordinates _coordinates;
        public Coordinates Coordinates
        {
            get { return _coordinates; }
            set
            {
                bool validation = 0 <= value.X && value.X < Room.Width && 0 <= value.Y && value.Y < Room.Depth;
                if (!validation)
                    throw new Exception(String.Format("Ny position [{0},{1}] ligger utanför befintlig rumsdimension [0-{2},0-{3}]. ",
                                                        value.X, value.Y, Room.Width - 1, Room.Depth - 1));
                _coordinates = value;
            }
        }


        protected Robot(Room room, int xStartPosition, int yStartPosition, Direction direction)
        {
            Room = room;
            CurrentDirection = direction;
            Coordinates = new Coordinates(xStartPosition, yStartPosition);
        }

        public abstract void Move(List<Command> commands);

        protected virtual void WalkStraight()
        {
            int xChange = 0;
            int yChange = 0;

            switch (CurrentDirection)
            {
                case Direction.Ö:
                    xChange++;
                    break;
                case Direction.S:
                    yChange++;
                    break;
                case Direction.V:
                    xChange--;
                    break;
                case Direction.N:
                    yChange--;
                    break;
                default:
                    throw new Exception("WalkStraight saknar hantering för riktning " + CurrentDirection);
            }
            Coordinates = new Coordinates(Coordinates.X + xChange, Coordinates.Y + yChange);
        }

        protected virtual void TurnLeft()
        {
            switch (CurrentDirection)
            {
                case Direction.Ö:
                    CurrentDirection = Direction.N;
                    break;
                case Direction.N:
                    CurrentDirection = Direction.V;
                    break;
                case Direction.V:
                    CurrentDirection = Direction.S;
                    break;
                case Direction.S:
                    CurrentDirection = Direction.Ö;
                    break;
                default:
                    throw new Exception("TurnLeft saknar hantering för riktning " + CurrentDirection);
            }
        }

        protected virtual void TurnRight()
        {
            switch (CurrentDirection)
            {
                case Direction.Ö:
                    CurrentDirection = Direction.S;
                    break;
                case Direction.S:
                    CurrentDirection = Direction.V;
                    break;
                case Direction.V:
                    CurrentDirection = Direction.N;
                    break;
                case Direction.N:
                    CurrentDirection = Direction.Ö;
                    break;
                default:
                    throw new Exception("TurnRight saknar hantering för riktning " + CurrentDirection);
            }
        }

        public override string ToString()
        {
            return Coordinates.X + " " + Coordinates.Y + " " + CurrentDirection;
        }
    }
}
