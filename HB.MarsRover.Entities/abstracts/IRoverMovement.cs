using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Entities.abstracts
{
    /// <summary>
    /// Movement model of Rover
    /// </summary>
    public interface IRoverMovement
    {
        /// <summary>
        /// Controlled Rover Object 
        /// </summary>
        public IRover Rover { get; set; }
        /// <summary>
        /// Moving Rover to Forward
        /// </summary>
        void MoveForward();
        /// <summary>
        /// Turning Rover Heading to Left
        /// </summary>
        void TurnLeft();
        /// <summary>
        /// Turning Rover Heading to Right
        /// </summary>
        void TurnRight();
    }
}
