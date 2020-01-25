using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarService.Commands
{
    public abstract class Command
    {
        public abstract void Execute();
    }

    public abstract class UndoableCommand : Command
    {
        public abstract void Undo();
    }

    public interface ICommandManager
    {
         void ExecuteCommand(Command cmd);
         void Undo();

    }
    public class CommandManger:ICommandManager
    {
            private Stack commandStack = new Stack();

            public void ExecuteCommand(Command cmd)
            {
                cmd.Execute();
                if (cmd is UndoableCommand)
                {
                    commandStack.Push(cmd);
                }
            }


            public void Undo()
            {
                if (commandStack.Count > 0)
                {
                    UndoableCommand cmd = (UndoableCommand)commandStack.Pop();
                    cmd.Undo();
                }
            }
        
    }

   
}
