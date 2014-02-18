namespace GridAttackSimulator
{
    public interface IAgent
    {
        IAction Act(IEnvironment environment);
        EnvironmentPosition Position { get; }
        bool IsAlive { get; }
        void InflictDamage(int damage);
    }

    public interface IAction
    {
        void Execute(IEnvironment environment);
    }

    public interface ICombatant : IAgent
    {
        int AttackDamage { get; }
        int AttackRange { get; }
    }
}
