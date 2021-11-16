using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurtlePath.Models
{
    public class Turtle
    {
        public Turtle()
        {
            Orientation = 'N';
            Location = new Cords(0, 0);
            Path = new List<TurtlePosition>();
            DuplicatePoints = new List<Cords>();

            //add starting location to the path
            Path.Add(new TurtlePosition(new Cords(0, 0), false));
        }
        //N,E,W,S
        public char Orientation { get; set; } //maybe a ENUM 
        public Cords Location { get; set; }

        public List<TurtlePosition> Path { get; set; }

        private List<Cords> DuplicatePoints { get; set; }

        private void RotateLeft()
        {
            switch (Orientation)
            {
                case 'N':
                    Orientation = 'W';
                    break;
                case 'S':
                    Orientation = 'E';
                    break;
                case 'E':
                    Orientation = 'N';
                    break;
                case 'W':
                    Orientation = 'S';
                    break;
            }
        }

        private void RotateRight()
        {
            switch (Orientation)
            {
                case 'N':
                    Orientation = 'E';
                    break;
                case 'S':
                    Orientation = 'W';
                    break;
                case 'E':
                    Orientation = 'S';
                    break;
                case 'W':
                    Orientation = 'N';
                    break;
            }
        }

        private void Forward()
        {
            switch (Orientation)
            {
                case 'N':
                    Location.Up();
                    break;
                case 'S':
                    Location.Down();
                    break;
                case 'E':
                    Location.Right();
                    break;
                case 'W':
                    Location.Left();
                    break;
            }
            Cords newLocation = new Cords(Location.X, Location.Y);

            bool isDuplicatePoint = CheckDuplicatePoints(newLocation);
            Path.Add(new TurtlePosition(newLocation, isDuplicatePoint));
        }

        private bool CheckDuplicatePoints(Cords cords)
        {
            if (Path.Any(point => point.Cords.X == cords.X && point.Cords.Y == cords.Y) //check if hit already
                && !DuplicatePoints.Any(point => point.X == cords.X && point.Y == cords.Y)) //check if already recorded
            {
                DuplicatePoints.Add(cords);
                return true;
            }

            if (DuplicatePoints.Any(point => point.X == cords.X && point.Y == cords.Y))
            {
                return true;
            }

            return false;
        }

        public void Move(char movement)
        {
            switch (movement)
            {
                case 'F':
                    Forward();
                    break;
                case 'R':
                    RotateRight();
                    break;
                case 'L':
                    RotateLeft();
                    break;

            }
        }


        public class TurtlePosition
        {
            public TurtlePosition(Cords cords, bool isDuplicate)
            {
                Cords = cords;
                IsDuplicate = isDuplicate;
            }
            //X, Y cordintates
            public Cords Cords { get; set; }

            //True if turtle visited this cordintates before
            public bool IsDuplicate { get; set; }
        }

    }

}

