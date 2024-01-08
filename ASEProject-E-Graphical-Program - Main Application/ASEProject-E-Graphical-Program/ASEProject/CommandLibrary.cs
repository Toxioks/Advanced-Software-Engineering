using ASEProject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

/// <summary>
/// Represents the Command Library class for executing a list/library of commands using a graphical object.
/// </summary>
public class CommandLibrary
{
    private Graphics graphics;
    private Pen pen;
    private PointF currentPenPosition;
    private Dictionary<string, int> keyVariable;

    /// <summary>
    /// Creates a new instance of the CommandLibrary class with the required object.
    /// </summary>
    /// <param name="graphics">The Graphics object stated within Form1.</param>
    public CommandLibrary(Graphics graphics)
    {
        this.graphics = graphics;
        pen = new Pen(Color.BlueViolet);
        currentPenPosition = PointF.Empty;
        keyVariable = new Dictionary<string, int>();
    }

    /// <summary>
    /// Returns the current pen color used for drawing, set within the CommandLibrary Grpahics object. Also used for Unit testing the Pen command.
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
            case "circle":
                DrawCircle(parts);
                break;
            case "clear":
                Clear();
                break;
            case "reset":
                Reset();
                break;
            case "pen":
                UpdatePenColor(parts);
                break;
            case "fill":
                UpdateFillMode(parts);
                break;
            case "rectangle":
                DrawRectangle(parts);
                break;
            case "triangle":
                DrawTriangle(parts);
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
        if (parts.Length >= 3)
        {
            int x = int.TryParse(parts[1], out var num) ? num : TryGetVariable(parts[1]);
            int y = int.TryParse(parts[2], out num) ? num : TryGetVariable(parts[2]);
            PointF endPoint = new PointF(x, y);
            graphics.DrawLine(pen, currentPenPosition, endPoint);
            currentPenPosition = endPoint;
        }
    }

    /// <summary>
    /// Locates the Pen object to the specified coordinates X & Y.
    /// </summary>
    /// <param name="parts">An array containing the moveTo command's X & Y coordinates.</param>
    public void MoveTo(string[] parts)
    {
        if (parts.Length >= 3)
        {
            int x = int.TryParse(parts[1], out var num) ? num : TryGetVariable(parts[1]);
            int y = int.TryParse(parts[2], out num) ? num : TryGetVariable(parts[2]);
            currentPenPosition = new PointF(x, y);
        }
    }

    /// <summary>
    /// Draw's a circle with a specified radius.
    /// </summary>
    /// <param name="parts">An array containing the circle command's created using the specified radius</param>
    public void DrawCircle(string[] parts)
    {
        if (parts.Length >= 2)
        {

            int radius;

            if (int.TryParse(parts[1], out radius))
            {
                MessageBox.Show($"Using radius: {radius}", "Debugger", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (keyVariable.TryGetValue(parts[1], out radius))
            {
                MessageBox.Show($"Variable: '{parts[1]}' for value: {radius}", "Debugger", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Radius value / variable '{parts[1]}' not found", "Debugger Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float diameter = radius * 2;
            RectangleF rect = new RectangleF(currentPenPosition.X - radius, currentPenPosition.Y - radius, diameter, diameter);

            // Drawing logic
            if (FillModeTrue)
            {
                graphics.FillEllipse(pen.Brush, rect);
            }
            graphics.DrawEllipse(pen, rect);
        }
        else
        {
            MessageBox.Show("Invalid command format for 'circle'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Clears the graphic and returns Pen position to original X & Y coordinates.
    /// </summary>
    public void Clear()
    {
        if (graphics != null)
        {

            graphics.Clear(Color.WhiteSmoke);
            currentPenPosition = PointF.Empty;
        }
    }

    /// <summary>
    /// Resets the current position to the original X & Y coordinates
    /// </summary>
    public void Reset()
    {
        currentPenPosition = PointF.Empty;
    }

    /// <summary>
    /// Changes the color of the pen based on the color selected.
    /// </summary>
    /// <param name="parts">An array containing the pen command and the colour name.</param>
    public void UpdatePenColor(string[] parts)
    {
        if (parts.Length >= 2)
        {
            string colorName = parts[1].ToLower();
            switch (colorName)
            {
                case "black":
                    pen.Color = Color.Black;
                    break;
                case "white":
                    pen.Color = Color.White;
                    break;
                case "red":
                    pen.Color = Color.Red;
                    break;
                case "blue":
                    pen.Color = Color.Blue;
                    break;
                case "green":
                    pen.Color = Color.Green;
                    break;
                case "yellow":
                    pen.Color = Color.Yellow;
                    break;
                case "pink":
                    pen.Color = Color.HotPink;
                    break;
                case "gold":
                    pen.Color = Color.Gold;
                    break;
                case "cyan":
                    pen.Color = Color.Cyan;
                    break;
                case "silver":
                    pen.Color = Color.Silver;
                    break;
                case "brown":
                    pen.Color = Color.Brown;
                    break;
                default:
                    // Invalid color name
                    break;
            }
        }
    }

    /// <summary>
    /// Changes the fill mode on or off. References FillModeTrue.
    /// </summary>
    /// <param name="parts">An array containing the Fill command.</param>
    public void UpdateFillMode(string[] parts)
    {
        if (parts.Length >= 2)
        {
            string fillMode = parts[1].ToLower();

            try
            {
                if (fillMode == "on")
                {
                    FillModeTrue = true;
                }
                else if (fillMode == "off")
                {
                    FillModeTrue = false;
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"Error: UpdateFillMode Failed");
            }
        }
    }

    /// <summary>
    /// Draws a rectangle at the with the input X & Y.
    /// </summary>
    /// <param name="parts">An array containing the Rectangle command's specified X & Y input.</param>
    public void DrawRectangle(string[] parts)
    {
        if (parts.Length >= 3)
        {
            int width = int.TryParse(parts[1], out var num) ? num : TryGetVariable(parts[1]);
            int height = int.TryParse(parts[2], out num) ? num : TryGetVariable(parts[2]);
            RectangleF rect = new RectangleF(currentPenPosition.X, currentPenPosition.Y, width, height);
            if (FillModeTrue)
            {
                graphics.FillRectangle(pen.Brush, rect);
            }
            graphics.DrawRectangle(pen, Rectangle.Round(rect));
        }
    }

    /// <summary>
    /// Draws a triangle at the with the 6 specified dimensions, width, height and coordinates.
    /// </summary>
    /// <param name="parts">An array containing the Triangle command's specified dimensions.</param>
    public void DrawTriangle(string[] parts)
    {
        if (parts.Length >= 6)
        {
            int xOne = int.TryParse(parts[1], out var numXOne) ? numXOne : TryGetVariable(parts[1]);
            int yOne = int.TryParse(parts[2], out var numYOne) ? numYOne : TryGetVariable(parts[2]);
            int xTwo = int.TryParse(parts[3], out var numXTwo) ? numXTwo : TryGetVariable(parts[3]);
            int yTwo = int.TryParse(parts[4], out var numYTwo) ? numYTwo : TryGetVariable(parts[4]);
            int xThree = int.TryParse(parts[5], out var numXThree) ? numXThree : TryGetVariable(parts[5]);
            int yThree = int.TryParse(parts[6], out var numYThree) ? numYThree : TryGetVariable(parts[6]);

            PointF[] points = { new PointF(xOne, yOne), new PointF(xTwo, yTwo), new PointF(xThree, yThree) };
            if (FillModeTrue)
            {
                graphics.FillPolygon(pen.Brush, points);
            }
            graphics.DrawPolygon(pen, points);
        }
    }

    /// <summary>
    /// Modifies and updates a set variable with a specified value set by the user.
    /// </summary>
    /// <param name="variableName">The name of the variable to modify or update.</param>
    /// <param name="value">The value/data to assign to the specified variable.</param>
    public void Variable(string variableName, int value)
    {
        keyVariable[variableName] = value;
    }

    /// <summary>
    /// Attempts to retrieve the specified variable name and returns the value.
    /// </summary>
    /// <param name="variableName">The specified name of the variable to retrieve .</param>
    public int TryGetVariable(string variableName)
    {
        if (keyVariable.TryGetValue(variableName, out int value))
        {
            return value;
        }
        else
        {
            throw new ArgumentException($"Variable {variableName} cannot be found");
        }
    }

    public void DisplayVariable(string variableName)
    {
        if (keyVariable.TryGetValue(variableName, out int value))
        {
            Console.WriteLine($"Variable {variableName} contains {value}");
            MessageBox.Show($"Variable '{variableName}' contains: {value}", "value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            Console.WriteLine($"Variable {variableName} is incorrectly defined: {value}");
            MessageBox.Show($"Variable '{variableName}' is incorrectly defined: {value}", "value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    /// <summary>
    /// Attempts to confirm the specified variable name exists. Returns true if it does, false if it doesn't.
    /// </summary>
    /// <param name="variableName">The specified name of the variable to retrieve .</param>
    public bool IsVariableName(string variableName)
    {
        return keyVariable.ContainsKey(variableName);
    }


    /// <summary>
    /// Gets or sets the fill mode for drawings. If true, the drawing will be filled. If false, the drawing will be outlined.
    /// </summary>
    internal bool FillModeTrue { get; set; } = true;

    /// <summary>
    /// Gets the current drawing position and returns the current pen position within the PointF graphics object
    /// </summary>
    public PointF GetCurrentPosition()
    {
        return currentPenPosition;
    }


}
