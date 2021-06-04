using HB.MarsRover.Builder;
using HB.MarsRover.Entities.abstracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HB.MarsRover.Tests
{
    [TestClass]
    public class MarsRoverTests
    {

        [TestMethod]
        public void FirstRoverTestWithValidInputs()
        {
            IMovementManagerBuilder movementManagerBuilder = new IMovementManagerBuilder();
            string plateauInput = "5 5";
            movementManagerBuilder.BuildPlateau(plateauInput);

            string roverInput = "1 2 N";
            movementManagerBuilder.BuildRover(roverInput);

            IRoverMovementManager movementManager = movementManagerBuilder.GetResult();
            char[] movements = "LMLMLMLMM".ToCharArray();
            foreach (char movementCommand in movements)
                movementManager.ProceedMovement(movementCommand);

            Assert.AreEqual("1 3 N", movementManager.Movement.Rover.ToString());
        }

        [TestMethod]
        public void SecondRoverTestWithValidInputs()
        {
            IMovementManagerBuilder movementManagerBuilder = new IMovementManagerBuilder();
            string plateauInput = "5 5";
            movementManagerBuilder.BuildPlateau(plateauInput);

            string roverInput = "3 3 E";
            movementManagerBuilder.BuildRover(roverInput);

            IRoverMovementManager movementManager = movementManagerBuilder.GetResult();
            char[] movements = "MMRMMRMRRM".ToCharArray();
            foreach (char movementCommand in movements)
                movementManager.ProceedMovement(movementCommand);

            Assert.AreEqual("5 1 E", movementManager.Movement.Rover.ToString());
        }


        [TestMethod]
        public void RoverTestWithWrongInputs()
        {
            IMovementManagerBuilder movementManagerBuilder = new IMovementManagerBuilder();
            string plateauInput = "5 5";
            movementManagerBuilder.BuildPlateau(plateauInput);

            string roverInput = "2 1 E";
            movementManagerBuilder.BuildRover(roverInput);

            IRoverMovementManager movementManager = movementManagerBuilder.GetResult();
            char[] movements = "MMRMMRMRRM".ToCharArray();
            foreach (char movementCommand in movements)
                movementManager.ProceedMovement(movementCommand);

            Assert.AreNotEqual("5 1 E", movementManager.Movement.Rover.ToString());
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RoverTestWithInvalidInputs()
        {
            IMovementManagerBuilder movementManagerBuilder = new IMovementManagerBuilder();
            string plateauInput = "5 5 5";
            movementManagerBuilder.BuildPlateau(plateauInput);

            string roverInput = "2 1 E";
            movementManagerBuilder.BuildRover(roverInput);

            IRoverMovementManager movementManager = movementManagerBuilder.GetResult();
            char[] movements = "MMRMMRMRRM".ToCharArray();
            foreach (char movementCommand in movements)
                movementManager.ProceedMovement(movementCommand);

            Assert.AreNotEqual("5 1 E", movementManager.Movement.Rover.ToString());
        }
    }
}
