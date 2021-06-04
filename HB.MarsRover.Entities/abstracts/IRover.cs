using HB.MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.MarsRover.Entities.abstracts
{
    public interface IRover
    {
        /// <summary>
        /// Rover Plateau which needs to move inside of it.
        /// </summary>
        IPlateau Plateau { get; set; }
        /// <summary>
        /// Rover Current Location
        /// </summary>
        IPosition CurrentLocation { get; set; }
        /// <summary>
        /// Rover Direction
        /// </summary>
        RoverCompassDirection Direction { get; set; }

    }
}
