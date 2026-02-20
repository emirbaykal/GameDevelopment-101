namespace GameDevelopment_101.Design_Patterns.CommandPattern.Interface
{
    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }
}