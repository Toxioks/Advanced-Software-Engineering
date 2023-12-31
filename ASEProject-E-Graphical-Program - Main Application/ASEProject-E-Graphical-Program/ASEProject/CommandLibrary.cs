﻿using ASEProject;
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
        if (parts.Length >= 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
        {
            PointF endPoint = new PointF(x, y);
            graphics.DrawLine(pen, currentPenPosition, endPoint);
            currentPenPosition = endPoint;
        }
    }

    /// <summary>
    /// Draw's a circle at the current pen position using the input radius
    /// </summary>
    /// <param name="parts">An array containing the circle command's created using the specified radius</param>
    public void MoveTo(string[] parts)
    {
        if (parts.Length >= 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
        {
            currentPenPosition = new PointF(x, y);
        }
    }

    /// <summary>
    /// Moves to the Pen to specified coordinates X & Y.
    /// </summary>
    /// <param name="parts">An array containing the moveTo command's X & Y coordinates.</param>
    public void DrawCircle(string[] parts)
    {
        if (parts.Length >= 2 && int.TryParse(parts[1], out int radius))
        {
            float diameter = radius * 2;
            RectangleF rect = new RectangleF(currentPenPosition.X, currentPenPosition.Y, diameter, diameter);
            if (FillModeTrue)
            {
                if (pen.Brush != null && pen.Brush != Brushes.Transparent)
                {
                    graphics.FillEllipse(pen.Brush, rect);
                }
            }
            graphics.DrawEllipse(pen, Rectangle.Round(rect));
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
        if (parts.Length >= 3 && int.TryParse(parts[1], out int width) && int.TryParse(parts[2], out int height))
        {
            RectangleF rect = new RectangleF(currentPenPosition.X, currentPenPosition.Y, width, height);
            if (FillModeTrue)
            {
                if (pen.Brush != null && pen.Brush != Brushes.Transparent)
                {
                    graphics.FillRectangle(pen.Brush, rect);
                }
            }
            graphics.DrawRectangle(pen, Rectangle.Round(rect));
        }
    }

    /// <summary>
    /// Draws a triangle at the with the 6 specified dimensions, width, height and coordinates.
    /// </summary>
    /// <param name="parts">An array containing the Triangle command's specified dimensions. </param>
    public void DrawTriangle(string[] parts)
    {
        if (parts.Length >= 6 && int.TryParse(parts[1], out int radius)
                       && int.TryParse(parts[2], out int height)
                                  && int.TryParse(parts[3], out int x2)
                                             && int.TryParse(parts[4], out int y2))
        {
            PointF[] points = new PointF[3];
            points[0] = new PointF(currentPenPosition.X, currentPenPosition.Y);
            points[1] = new PointF(radius, height);
            points[2] = new PointF(x2, y2);
            if (FillModeTrue)
            {
                if (pen.Brush != null && pen.Brush != Brushes.Transparent)
                {
                    graphics.FillPolygon(pen.Brush, points);
                }
            }
            graphics.DrawPolygon(pen, points);
        }
    }   

    public void variable(string variableName, int valueVariable)
    {
        keyVariable[variableName] = valueVariable;
    }
    public int TryGetVariable(string variableName)
    {
        if (keyVariable.TryGetValue(variableName, out int valueVariable))
        {
            return valueVariable;
        }
        else
        {
            throw new ArgumentException($"Variable {variableName} cannot be found");
        }
    }

    public void DisplayVariable(string variableName)
    {
        if (keyVariable.TryGetValue(variableName, out int valueVariable))
        {
            Console.WriteLine($"Variable {variableName} contains {valueVariable}");
            MessageBox.Show($"Variable '{variableName}' contains: {valueVariable}", "value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            Console.WriteLine($"Variable {variableName} is incorrectly defined: {valueVariable}");
            MessageBox.Show($"Variable '{variableName}' is incorrectly defined: {valueVariable}", "value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public bool IsVariableName(string variableName)
    {
        return keyVariable.ContainsKey(variableName);
    }


    /// <summary>
    /// Gets or sets the fill mode for drawings. If true, the drawing will be filled. If false, the drawing will be outlined.
    /// </summary>
    internal bool FillModeTrue { get; set; } = true;

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
