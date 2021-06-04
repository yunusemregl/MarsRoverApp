using System;
using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.Entities.abstracts
{
    public interface IRoverMovementManager
    {
        void ProceedMovement(char movementsCommand);
        bool CheckCommandIsValid(char movementsCommands);
        public IRoverMovement Movement { get; set; }
    }
}
