using HB.MarsRover.Builder;
using HB.MarsRover.Entities.abstracts;
using HB.MarsRover.Entities.Concretes;
using HB.MarsRover.Enums;
using System;
using System.Collections.Generic;

namespace HB.MarsRover.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             1.Build Plateau object with its initial borders cordinates.
             2.Test Rover Movements on Plateau for 2 rover.
             2.1.Build Rover object and its initial position at Plateau with user inputs
             2.2.Build RoverMovementManager object to move rover on Plateau by user inputs
             3.Show final positions and directions of rovers as an output at screen
             */

            IMovementManagerBuilder movementManagerBuilder = new IMovementManagerBuilder();


            Console.WriteLine("Please enter test inputs:");

            #region 1.Build Plateau object with its initial borders cordinates.

            do
            {
                try
                {
                    // init plateau with reading from console.
                    string plateauInput = Console.ReadLine();
                    movementManagerBuilder.BuildPlateau(plateauInput);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Invalid plateau position input. Please try again!");
                }
            } while (movementManagerBuilder.Plateau == null);

            #endregion

            #region 2.Test Rover Movements on Plateau for 2 rover.
            //First Rover Movements
            IRover rover1 = TestRoverMovement(movementManagerBuilder);

            //Second Rover Movements
            IRover rover2 = TestRoverMovement(movementManagerBuilder);

            #endregion

            #region 3.Show final positions and directions of rovers as an output at screen
            Console.WriteLine("Outputs:");

            Console.WriteLine(rover1.ToString());
            Console.WriteLine(rover2.ToString());


            #endregion

            Console.ReadLine();
        }


        private static IRover TestRoverMovement(IMovementManagerBuilder movementManagerBuilder)
        {

            #region  2.1.Build Rover object and its initial position at Plateau with user inputs

            do
            {
                try
                {
                    // init rover initial position
                    string roverInput = Console.ReadLine();
                    movementManagerBuilder.BuildRover(roverInput);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Invalid rover position input. Please try again!");
                }
            } while (movementManagerBuilder.Rover == null);

            #endregion

            #region 2.2.Build RoverMovementManager object to move rover on Plateau by user inputs

            IRoverMovementManager movementManager = movementManagerBuilder.GetResult();

            // init rover initial position by user inputs
            string roverMovementInput = Console.ReadLine();
            char[] movements = roverMovementInput.ToCharArray();
            if (movements.Length < 1)
            {
                Console.WriteLine("Please enter any valid direction to move rover.");
            }

            foreach (char movementCommand in movements)
            {
                movementManager.ProceedMovement(movementCommand);
            }

            // Returning rover object moved by user inputs
            return movementManager.Movement.Rover;

            #endregion

        }


    }
}
