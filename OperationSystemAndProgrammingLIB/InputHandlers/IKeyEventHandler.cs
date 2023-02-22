using System.Windows;
using System.Windows.Input;

namespace OperationSystemAndProgrammingLIB.InputHandlers;

/// <summary>
/// Represents key event handler interface for Window class.
/// </summary>
public interface IKeyEventHandler
{
    /// <summary>
    /// Keyboard key react on.
    /// </summary>
    Key CallableCombination { get; }

    /// <summary>
    /// Keyboard modifier key react on.
    /// </summary>
    ModifierKeys ModifierKey { get; }

    /// <summary>
    /// Defines is key combination pressed.
    /// </summary>
    /// <param name="args">Arguments of the key pressed event.</param>
    /// <returns>
    /// <c>true</c> if key combination is pressed.<br/>
    /// <c>false</c> - otherwise.
    /// </returns>
    bool IsPressed(KeyEventArgs args);

    /// <summary>
    /// Handle event for the specified window.
    /// </summary>
    /// <param name="source">Window where key was pressed.</param>
    /// <param name="args">Arguments of the key pressed event.</param>
    void HadleEvent(Window source, KeyEventArgs? args=null); 
}
