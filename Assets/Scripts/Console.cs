using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Console : MonoBehaviour
{
    private List<ConsoleCommand> _commands;

    void Start()
    {
        _commands = new List<ConsoleCommand>();
        _commands.Add(new DebugLogCommand());
        _commands.Add(new FixBlitzkriegCommand());
    }

    public string InputString(string value)
    {
        var arguments = value.Split(' ');
        var command = _commands.FirstOrDefault(_ => _.CompareNameApproximate(arguments[0]));
        
        if (command != null)
        {
            var context = new ConsoleCommandContext(arguments[1]);
            command.Execute(context);
        }

        return string.Empty;
    }

    public string GetHint(string value)
    {
        return "Possible commands:" +
            _commands
                .Where(_ => _.CompareNameApproximate(value))
                .Aggregate(string.Empty, (total, each) => total + System.Environment.NewLine + "\t " + each.GetCommandName());
    }

    private bool IsCommand()
    {
        return true;
    }
}
