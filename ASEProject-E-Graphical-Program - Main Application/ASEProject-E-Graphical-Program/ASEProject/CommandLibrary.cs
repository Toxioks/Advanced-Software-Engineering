using System;
using System.Collections.Generic;
using System.Drawing;

/// <summary>
/// Represents the Command Library class for executing a list/library of commands using a graphical object.
/// </summary>
public class CommandLibrary
{
    private Graphics graphics;
    private Pen pen;
    private PointF currentPenPosition;

    /// <summary>
    /// Creates a new instance of the CommandLibrary class with the required object.
    /// </summary>
    /// <param name="graphics">The Graphics object stated within Form1.</param>
    public CommandLibrary(Graphics graphics)
    {
        this.graphics = graphics;
        pen = new Pen(Color.BlueViolet);
        currentPenPosition = PointF.Empty;
    }

    /// <summary>
    /// Returns the current pen color used for drawing, set within the CommandLibrary Grpahics object.
    /// </summary>
    public Color GetPenColor()
    {
        return pen.Color;
    }

    /// <summary>
    /// Executes the entered command using a Switch expression containg required commands.
    /// </summary>
    /// <param name="command">A string representing the command entry.</param>
    /// 
    public void ExecuteCommandEntry(string command)
    {
        string[] parts = command.Split(' ');

        if (parts.Length < 2)
        {
            // Invalid command
            return;
        }

        string action = parts[0].ToLower();
        switch (action)
        {
            case "drawto":
                DrawTo(parts);
                break;
            case "moveto":
                MoveTo(parts);
                break;
            default:
                // Unknown command
                break;
        }
    }

    /// <summary>
    /// Drawes a line between the two specified coordinates X & Y.
    /// </summary>
    /// <param name="parts">An array containing the drawTo command's X & Y coordinates.</param>
    public void DrawTo(string[] parts)
    {
        if (parts.Length >= 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
        {
            PointF endPoint = new PointF(x, y);
            graphics.DrawLine(pen, currentPenPosition, endPoint);
            currentPenPosition = endPoint;
        }
    }

    /// <summary>
    /// Moves to the Pen to specified coordinates X & Y.
    /// </summary>
    /// <param name="parts">An array containing the moveTo command's X & Y coordinates.</param>
    public void MoveTo(string[] parts)
    {
        if (parts.Length >= 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
        {
            currentPenPosition = new PointF(x, y);
        }
    }

    /// <summary>
    /// Gets or sets the fill mode for drawings. If true, the drawing will be filled. If false, the drawing will be outlined.
    /// </summary>
    internal bool FillModeOn { get; set; } = true;

    public PointF GetCurrentPosition()
    {
        return currentPenPosition;
    }

    /// <summary>
    /// Creates a new instance of the CommandList class without a object. Used for testing purposes.
    /// </summary>
    public CommandLibrary()
    {

    }
}
