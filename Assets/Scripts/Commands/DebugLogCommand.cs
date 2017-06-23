using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogCommand : ConsoleCommand
{
    public override void Execute(ConsoleCommandContext context)
    {
        Debug.Log(context.GetArgument());
    }
}
