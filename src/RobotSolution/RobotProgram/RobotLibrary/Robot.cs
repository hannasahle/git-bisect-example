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
                    throw new Exception(String.Format("New position [{0},{1}] is out of bound, room dimensions are [0-{2},0-{3}]. ",
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
                case Direction.East:
                    xChange++;
                    break;
                case Direction.South:
                    yChange++;
                    break;
                case Direction.West:
                    xChange--;
                    break;
                case Direction.North:
                    yChange--;
                    break;
                default:
                    throw new Exception("Walk has no implementation for " + CurrentDirection);
            }
            Coordinates = new Coordinates(Coordinates.X + xChange, Coordinates.Y + yChange);
        }

        protected virtual void TurnLeft()
        {
            switch (CurrentDirection)
            {
                case Direction.East:
                    CurrentDirection = Direction.North;
                    break;
                case Direction.North:
                    CurrentDirection = Direction.West;
                    break;
                case Direction.West:
                    CurrentDirection = Direction.South;
                    break;
                case Direction.South:
                    CurrentDirection = Direction.East;
                    break;
                default:
                    throw new Exception("TurnLeft has no implementation for " + CurrentDirection);
            }
        }

        protected virtual void TurnRight()
        {
            switch (CurrentDirection)
            {
                case Direction.East:
                    CurrentDirection = Direction.South;
                    break;
                case Direction.South:
                    CurrentDirection = Direction.West;
                    break;
                case Direction.West:
                    CurrentDirection = Direction.North;
                    break;
                case Direction.North:
                    CurrentDirection = Direction.East;
                    break;
                default:
                    throw new Exception("TurnRight has no implementation for " + CurrentDirection);
            }
        }

        public override string ToString()
        {
            return Coordinates.X + " " + Coordinates.Y + " " + CurrentDirection;
        }
    }
}
