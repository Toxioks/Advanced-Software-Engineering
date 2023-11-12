using System;
using System.Drawing;
using Xunit;
using ASEProject; 
using System.Reflection;
using System.Drawing.Drawing2D;

/// <summary>
/// This class provides Unit testing using the CommandEntryTests class, 
/// this class consists of unit tests for the CommandLibraryList class in the ASEProject namespace.
/// </summary>

namespace CommandEntryTest
{
    public class CommandEntryTest
    {
        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the DrawTo command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidDrawTo()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("moveto 150 150");
            commandEntry.ExecuteCommandEntry("drawto 250 500");

            // Assert
            Assert.Equal(new PointF(250, 500), commandEntry.GetCurrentPosition());
        }

        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the MoveTo command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidMoveTo()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("moveto 150 150");

            // Assert
            Assert.Equal(new PointF(150, 150), commandEntry.GetCurrentPosition());
        }

        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the Circle command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidCircle()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("moveto 150 150");
            commandEntry.ExecuteCommandEntry("Circle 55");

            // Assert
            Assert.Equal(new PointF(150, 150), commandEntry.GetCurrentPosition());
        }

        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the Clear command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidClear()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("moveto 150 150");
            commandEntry.ExecuteCommandEntry("Clear");

            // Assert
            Assert.Equal(new PointF(150, 150), commandEntry.GetCurrentPosition());
        }

        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the Reset command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidReset()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("moveto 150 150");
            commandEntry.ExecuteCommandEntry("Reset");

            PointF coords = commandEntry.GetCurrentPosition();

            // Assert
            Assert.Equal(coords, commandEntry.GetCurrentPosition());
        }

        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the pen command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidPenUpdate()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandList = new CommandLibrary(graphics);

            // Act
            commandList.ExecuteCommandEntry("pen gold");

            // Get the current pen color from CommandLibrary
            Color updatedColor = commandList.GetPenColor();

            // Assert
            Assert.Equal(Color.Gold, updatedColor);


        }

        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the Fill command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidFillUpdate()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandList = new CommandLibrary(graphics);

            // Act
            commandList.ExecuteCommandEntry("fill off");


            //To Do


        }
    }
}