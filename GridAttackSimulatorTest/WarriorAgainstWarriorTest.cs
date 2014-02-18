using System.Collections.Generic;
using GridAttackSimulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GridAttackSimulatorTest
{
    [TestClass]
    public class WarriorAgainstWarriorTest
    {
        [TestMethod]
        public void WeakestWarriorShouldDieInSimulation()
        {
            var strongWarrior = new Warrior(attackDamage: 10, attackRange: 1, health: 100);
            var weakWarrior = new Warrior(attackDamage: 5, attackRange: 1, health: 100);
            var environment = new TestEnvironment(strongWarrior, weakWarrior);
            var simulator = new Simulator(environment);

            simulator.Simulate(10);

            Assert.IsFalse(weakWarrior.IsAlive);
        }
    }

    public class TestEnvironment : IEnvironment
    {
        private IAgent[] _agents;
        
        public TestEnvironment(params IAgent[] agents)
        {
            _agents = agents;
        }

        public IEnumerable<IAgent> Agents()
        {
            return _agents;
        }

        public bool IsPositionWithinBounds(EnvironmentPosition position)
        {
            return true;
        }

        public IEnumerable<IAgent> AgentsNear(EnvironmentPosition position, int distance)
        {
            return _agents;
        }
    }
}
