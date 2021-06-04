using HB.MarsRover.Entities.abstracts;
using HB.MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Entities.Concretes
{
    public class RoverMovementManager : IRoverMovementManager
    {
        public IRoverMovement Movement { get; set; }

        public RoverMovementManager(IRoverMovement movement)
        {
            this.Movement = movement;
        }

        /// <summary>
        /// Proceeding the movement by incoming command
        /// </summary>
        /// <param name="movementsCommand"></param>
        public void ProceedMovement(char movementsCommand)
        {
            if (!CheckCommandIsValid(movementsCommand))
                throw new ArgumentOutOfRangeException("Invalid movement direction.");

            RoverMovementCommandType roverMovementCommand = (RoverMovementCommandType)Enum.Parse(typeof(RoverMovementCommandType), movementsCommand.ToString());
            switch (roverMovementCommand)
            {
                case RoverMovementCommandType.L:
                    this.Movement.TurnLeft();
                    break;
                case RoverMovementCommandType.R:
                    this.Movement.TurnRight();
                    break;
                case RoverMovementCommandType.M:
                    this.Movement.MoveForward();
                    break;
                default:
                    break;
            }
        }
        
        /// <summary>
        /// Check command has valid format
        /// </summary>
        /// <param name="movementsCommand"></param>
        /// <returns></returns>
        public bool CheckCommandIsValid(char movementsCommand)
        {
            return Enum.IsDefined(typeof(RoverMovementCommandType), movementsCommand.ToString());
        }


    }
}
