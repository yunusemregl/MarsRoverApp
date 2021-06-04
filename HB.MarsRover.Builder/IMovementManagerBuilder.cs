using HB.MarsRover.Entities.abstracts;
using HB.MarsRover.Entities.Concretes;
using HB.MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Builder
{

    /// <summary>
    /// Builder Pattern Class which is building Plateau and Rover Objects
    /// </summary>
    public class IMovementManagerBuilder
    {
        public IRover Rover { get; set; }
        public IPlateau Plateau { get; set; }

        /// <summary>
        /// Create Plateau object instance from plateau initial cordinates
        /// </summary>
        /// <param name="plateauInput"></param>
        public void BuildPlateau(string plateauInput)
        {
            if (plateauInput.Split(" ").Length != 2)
                throw new ArgumentOutOfRangeException("Invalid rover input!");

            if (Int32.TryParse(plateauInput.Split(" ")[0], out int xOfPlateauCordinate) && Int32.TryParse(plateauInput.Split(" ")[1], out int yOfPlateauCordinate))
            {
                IPosition plateauPosition = new Position(xOfPlateauCordinate, yOfPlateauCordinate);

                this.Plateau = new Plateau(plateauPosition);
            }
            else
                throw new ArgumentOutOfRangeException("Invalid plateau input!");
        }

        /// <summary>
        /// Create Rover objet instance from roverInput initial cordinates at Plateau. It also uses Plateau object to know borders of plateau while moving on it. 
        /// </summary>
        /// <param name="roverInput"></param>
        public void BuildRover(string roverInput)
        {
            if (roverInput.Split(" ").Length != 3)
            {
                throw new ArgumentOutOfRangeException("Invalid plateau input!");
            }

            //check exist valid inputs
            if (Int32.TryParse(roverInput.Split(" ")[0], out int xOfRoverCordinate) &&
                Int32.TryParse(roverInput.Split(" ")[1], out int yOfRoverCordinate) &&
                Enum.IsDefined(typeof(RoverCompassDirection), roverInput.Split(" ")[2]))
            {
                IPosition roverPosition = new Position(xOfRoverCordinate, yOfRoverCordinate);

                RoverCompassDirection roverCompassDirection = (RoverCompassDirection)Enum.Parse(typeof(RoverCompassDirection), roverInput.Split(" ")[2]);

                this.Rover = new Rover(roverPosition, roverCompassDirection, this.Plateau);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid plateau input!");
            }
        }

        /// <summary>
        /// Return IMOvementManager which is using rover and plateau
        /// </summary>
        /// <returns></returns>
        public IRoverMovementManager GetResult()
        {
            IRoverMovement movement = new RoverMovement(this.Rover);

            IRoverMovementManager movementManager = new RoverMovementManager(movement);

            return movementManager;
        }



    }
}
