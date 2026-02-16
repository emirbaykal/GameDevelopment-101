namespace GameDevelopment_101.Design_Patterns.StatePattern.Interface
{
    public interface IState
    {
        public void EnterState(PlayerController player);
        public void UpdateState(PlayerController player);
        public void ExitState(PlayerController player);
    }
}