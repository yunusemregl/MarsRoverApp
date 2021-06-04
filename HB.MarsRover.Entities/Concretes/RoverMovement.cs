using HB.MarsRover.Entities.abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Entities.Concretes
{
    public class RoverMovement : IRoverMovement
    {
        public RoverMovement(IRover rover)
        {
            this.Rover = rover;
        }


        public IRover Rover { get; set; }

        /// <summary>
        /// Move forward if not reached to the borders of plateau.
        /// </summary>
        public void MoveForward()
        {
            switch (Rover.Direction)
            {
                case Enums.RoverCompassDirection.N:
                    if (Rover.Plateau.Position.Y > Rover.CurrentLocation.Y)
                        Rover.CurrentLocation.Y++;
                    break;
                case Enums.RoverCompassDirection.W:
                    if (Rover.CurrentLocation.X > 0)
                        Rover.CurrentLocation.X--;
                    break;
                case Enums.RoverCompassDirection.S:
                    if (Rover.CurrentLocation.Y > 0)
                        Rover.CurrentLocation.Y--;
                    break;
                case Enums.RoverCompassDirection.E:
                    if (Rover.Plateau.Position.X > Rover.CurrentLocation.X)
                        Rover.CurrentLocation.X++;
                    break;
                default:
                    break;
            };

        }

        /// <summary>
        /// Turn left which is using the four cardinal compass points
        /// </summary>
        public void TurnLeft()
        {
            Rover.Direction = Rover.Direction == Enums.RoverCompassDirection.E ? Enums.RoverCompassDirection.N : Rover.Direction + 1;
        }

        /// <summary>
        /// Turn right which is using the four cardinal compass points
        /// </summary>
        public void TurnRight()
        {
            Rover.Direction = Rover.Direction == Enums.RoverCompassDirection.N ? Enums.RoverCompassDirection.E : Rover.Direction - 1;
        }
    }
}
