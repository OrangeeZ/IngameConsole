using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleCommandContext
{
    private string[] _arguments;

    public ConsoleCommandContext(string[] arguments)
    {
        _arguments = arguments;
    }

    public ConsoleCommandContext(string argument)
    {
        _arguments = new[] { argument };
    }

    public string GetArgument()
    {
        return _arguments.Length > 0 ? _arguments[0] : string.Empty;
    }
}
