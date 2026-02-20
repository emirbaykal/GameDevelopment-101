using System.Collections.Generic;
using GameDevelopment_101.Design_Patterns.CommandPattern.Interface;

namespace GameDevelopment_101.Design_Patterns.CommandPattern
{
    public class CommandInvoker
    {
        private Stack<ICommand> history = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            // We add to the top of the stack.
            history.Push(command);
        }

        public void Undo()
        {
            if (history.Count > 0)
            {
                // We remove the item from the top of the stack.
                ICommand lastCommand = history.Pop();
                lastCommand.Undo();
            }
        }
    }
}