using OperationSystemAndProgrammingLIB.InputHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;

namespace Notepad.InputHadlers;

public static class KeyHandlersAccessor
{
    private static readonly List<IKeyEventHandler?> _handlers;

    static KeyHandlersAccessor()
    {
        _handlers = Assembly.GetAssembly(typeof(NotepadKeyEventHandler))?.GetTypes()
            .Where(t => t.IsAbstract == false && t.IsSubclassOf(typeof(NotepadKeyEventHandler)))
            .Select(t => Activator.CreateInstance(t) as IKeyEventHandler)
            .ToList() ?? new List<IKeyEventHandler?>();
    }

    public static IKeyEventHandler? GetHandler(KeyEventArgs args) 
        => _handlers.FirstOrDefault(handler => handler?.IsPressed(args) ?? false);

    public static IKeyEventHandler? GetHandler(string name)
        => _handlers.FirstOrDefault(handler => handler?.GetType().Name.Equals(name) ?? false);
}
