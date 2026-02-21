namespace GameDevelopment_101.Design_Patterns.ObjectPooling.Interfaces
{
    public interface IPoolable
    {
        public void OnPulledToPool();
        public void OnReturnedToPool();
    }
}