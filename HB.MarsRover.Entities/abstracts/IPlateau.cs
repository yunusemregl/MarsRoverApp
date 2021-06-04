using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.MarsRover.Entities.abstracts
{
    /// <summary>
    /// A plateau at Mars which rovers needs to moving on it to discover complete view of the surrounding terrain with their cameras
    /// </summary>
    public interface IPlateau
    {
        public IPosition Position { get; set; }

    }
}
