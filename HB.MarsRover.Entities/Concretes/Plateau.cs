using HB.MarsRover.Entities.abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Entities.Concretes
{

    public class Plateau : IPlateau
    {
        public IPosition Position { get; set; }
        public Plateau(IPosition position)
        {
            this.Position = position;
        }
    }
}
