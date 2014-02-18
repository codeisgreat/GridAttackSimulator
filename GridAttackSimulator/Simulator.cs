using System.Linq;

namespace GridAttackSimulator
{
    public class Simulator
    {
        private readonly IEnvironment _environment;

        public Simulator(IEnvironment environment)
        {
            _environment = environment;
        }

        public void Simulate(int numberOfRounds)
        {
            while (numberOfRounds-- > 0)
            {
                var actions = _environment.Agents().Select(agent => agent.Act(_environment));
                
                foreach(var action in actions)
                {
                    action.Execute(_environment);
                }

                //todo: reason to stop the simulation? one side won?
            }
        }
    }
}
