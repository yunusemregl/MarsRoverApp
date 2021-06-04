using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.MarsRover.Entities.abstracts
{
    /// <summary>
    /// Position which is consist of X and Y coordinates
    /// </summary>
    public interface IPosition
    {
        /// <summary>
        /// X Coordinate
        /// </summary>
        int X { get; set; }
        /// <summary>
        /// Y Cordinate
        /// </summary>
        int Y { get; set; }
    }
}
