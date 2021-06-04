using HB.MarsRover.Entities.abstracts;
using HB.MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Entities.Concretes
{
    public class Rover : IRover
    {
        public IPosition CurrentLocation { get; set; }
        public RoverCompassDirection Direction { get; set; }
        public IPlateau Plateau { get; set; }

        public Rover(IPosition position, RoverCompassDirection roverCompassDirection, IPlateau plateau)
        {
            this.CurrentLocation = position;
            this.Direction = roverCompassDirection;
            this.Plateau = plateau;
        }
        /// <summary>
        /// Customized Override of Rover which is showing the rover current cordinates and direction like X Y D  (D means Direction)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.CurrentLocation.X} {this.CurrentLocation.Y} {this.Direction.ToString()}";
        }
    }
}
