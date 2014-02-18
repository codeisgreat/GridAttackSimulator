using System.Collections.Generic;

namespace GridAttackSimulator
{
    public interface IEnvironment
    {
        IEnumerable<IAgent> Agents();
        bool IsPositionWithinBounds(EnvironmentPosition position);
        IEnumerable<IAgent> AgentsNear(EnvironmentPosition position, int distance);
    }
}
