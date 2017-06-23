using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleImWindow : MonoBehaviour
{
    [SerializeField]
    private Console _console;

    private Stack<string> _messageStack = new Stack<string>();

    private string _currentInputString = string.Empty;

    void OnGUI()
    {
        DrawMessageStack();

        if (DrawInputField(ref _currentInputString))
        {
            var output = _console.InputString(_currentInputString);
            _messageStack.Push(output);
            
            _currentInputString = string.Empty;
        }
    }

    private void DrawMessageStack()
    {
        foreach (var each in _messageStack)
        {
            GUILayout.Label(each);
        }
    }

    private bool DrawInputField(ref string inputString)
    {
        if (Event.current.type == EventType.KeyDown)
        {
            if (Event.current.keyCode == KeyCode.Return)
            {
                return true;
            }

            if (Event.current.keyCode == KeyCode.Tab)
            {
                _messageStack.Push(_console.GetHint(inputString));
            }
        }

        inputString = GUILayout.TextField(inputString, GUILayout.MinWidth(100));

        return false;
    }
}
