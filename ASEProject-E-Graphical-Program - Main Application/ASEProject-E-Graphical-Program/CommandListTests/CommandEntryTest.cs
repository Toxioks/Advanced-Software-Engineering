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
        /// Verifies that the ExecuteCommand method correctly handles the "DrawTo" command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidDrawTo()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("moveto 50 50");
            commandEntry.ExecuteCommandEntry("drawto 100 100");

            // Assert
            Assert.Equal(new PointF(100, 100), commandEntry.GetCurrentPosition());
        }

        
    }
}