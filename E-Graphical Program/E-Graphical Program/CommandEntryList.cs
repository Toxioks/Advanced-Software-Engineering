using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace E_Graphical_Program
{
    /// <summary>
    /// Represents a class for executing a list of drawing commands using a Graphics object and a Pen.
    /// </summary>
    public class CommandEntryList
    {
        private Graphics graphics;
        private Pen pen;
        private PointF currentPosition;

        public CommandEntryList(Graphics graphics)
        {
            this.graphics = graphics;
            pen = new Pen(Color.White);
            currentPosition = PointF.Empty;
        }

        public Color ActivePenColor()
        {
            return pen.Color;
        }
        public CommandEntryList()
        {

        }

        public void ExecuteCommand(string command)
        {
            string[] parts = command.Split(' ');

            if (parts.Length < 2)
            {
                // Return Invalid command entry
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

        public void DrawTo(string[] parts)
        {
            if (parts.Length >= 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
            {
                PointF endPoint = new PointF(x, y);
                graphics.DrawLine(pen, currentPosition, endPoint);
                currentPosition = endPoint;
            }
        }

        public void MoveTo(string[] parts)
        {
            if (parts.Length >= 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
            {
                currentPosition = new PointF(x, y);
            }
        }

    }
}


