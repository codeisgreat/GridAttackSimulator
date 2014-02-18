using System.Linq;
using GridAttackSimulator.Actions;

namespace GridAttackSimulator
{
    public class Warrior : ICombatant
    {
        public int AttackRange { get; private set; }
        public int AttackDamage { get; private set; }
        public int Health { get; private set; }


        public Warrior(int attackRange, int attackDamage, int health)
        {
            AttackRange = attackRange;
            AttackDamage = attackDamage;
            Health = health;
        }

        public IAction Act(IEnvironment environment)
        {
            if (!IsAlive)
            {
                return new DoNothingAction();
            }

            //attack any agent within range
            var target = environment.AgentsNear(Position, AttackRange).FirstOrDefault(agent => agent != this);
            if (target != null)
            {
                return new AttackAgentAction(attacker: this, target: target);
            }

            return new DoNothingAction();
        }

        public bool IsAlive {
            get { return Health > 0; }
        }

        public void InflictDamage(int damage)
        {
            Health -= damage;
        }

        public EnvironmentPosition Position { get; private set; }
    }

    public class AttackAgentAction : IAction
    {
        private readonly ICombatant _attacker;
        private readonly IAgent _target;

        public AttackAgentAction(ICombatant attacker, IAgent target)
        {
            _attacker = attacker;
            _target = target;
        }

        public void Execute(IEnvironment environment)
        {
            _target.InflictDamage(_attacker.AttackDamage);
        }
    }
}
