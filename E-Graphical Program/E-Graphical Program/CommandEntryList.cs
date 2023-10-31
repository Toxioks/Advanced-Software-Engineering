using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace E_Graphical_Program
{
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

        public void ExecuteCommand(string command)
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
                    break;
                default:
                    // Unknown command
                    break;
            }
        }
    }
}


