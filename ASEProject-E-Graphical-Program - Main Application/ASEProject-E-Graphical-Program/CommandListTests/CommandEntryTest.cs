using System;
using System.Drawing;
using Xunit;
using ASEProject; 
using System.Reflection;

/// <summary>
/// This class provides Unit testing using the CommandEntryTests class, 
/// this class consists of unit tests for the CommandLibraryList class in the ASEProject namespace.
/// </summary>

namespace CommandEntryTest
{
    public class CommandEntryTest
    {
        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the "DrawTo" command.
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
        /// Calls ExecuteCommandEntry method and handles the "MoveTo" command.
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
            Assert.Equal(new PointF(250, 500), commandEntry.GetCurrentPosition());
        }


    }
}