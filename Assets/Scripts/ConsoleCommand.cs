using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleCommand
{
    public bool CompareName(string name)
    {
        return GetCommandName() == name;
    }

    public bool CompareNameApproximate(string name)
    {
        return GetCommandName().StartsWith(name) || GetCommandName().Contains(name);
    }

    public virtual void Execute(ConsoleCommandContext context)
    {
        
    }

    public virtual string GetCommandName()
    {
        return GetType().Name.ToLower().Replace("command", string.Empty);
    }
}
