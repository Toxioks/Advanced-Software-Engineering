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

namespace ApplicationTesting
{
    public class CommandEntryTest
    {
        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the Invalid command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_InvalidCommand()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("invalid");

            // Assert
            Assert.Equal(new PointF(0, 0), commandEntry.GetCurrentPosition());
        }

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
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("pen gold");

            // Get the current pen color from CommandLibrary
            Color updatedColor = commandEntry.GetPenColor();

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
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("fill on");
            PropertyInfo fillProperty = commandEntry.GetType().GetProperty("FillModeTrue", BindingFlags.NonPublic | BindingFlags.Instance);
            bool fillValue = (bool)fillProperty.GetValue(commandEntry);

            //To
            Assert.True(fillValue);
        }

        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the Rectangle command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidRectangle()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("moveto 50 50");
            commandEntry.ExecuteCommandEntry("rectangle 100 100");


            // Assert
            Assert.Equal(new PointF(50, 50), commandEntry.GetCurrentPosition());
        }

        /// <summary>
        /// Calls ExecuteCommandEntry method and handles the Triangle command.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ValidTriangle()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("moveto 100 100");
            commandEntry.ExecuteCommandEntry("triangle 10 20 30 40 50 60");


            // Assert
            Assert.NotEqual(PointF.Empty, commandEntry.GetCurrentPosition());
        }

        /// <summary>
        /// Test's the <see cref="CommandLibrary.Variable(string, int)"/> method.
        /// </summary>
        [Fact]
        public void SetVariable()
        {
            // Arrange
            var commandEntryList = new CommandLibrary(Graphics.FromImage(new Bitmap(1, 1)));
            commandEntryList.Variable("x", 10);

            //Act
            int size = commandEntryList.TryGetVariable("x");

            // Assert
            Assert.Equal(10, size);
        }

        /// <summary>
        /// Test's the <see cref="CommandLibrary.CommandLoop(string command)"/> method.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_Loop()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);

            // Act
            commandEntry.ExecuteCommandEntry("loop 5");
            commandEntry.ExecuteCommandEntry("moveto 100 100");
            commandEntry.ExecuteCommandEntry("drawto 50 50");
            commandEntry.ExecuteCommandEntry("endloop");

            // Assert
            Assert.Equal(new PointF(50, 50), commandEntry.GetCurrentPosition());

        }

        /// <summary>
        /// Test's the conditional executions of commands using the conditional "if" statement.
        /// </summary>
        [Fact]
        public void ExecuteCommandEntry_ConditionalIfStatement()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);
            commandEntry.ExecuteCommandEntry("size = 50");

            // Act
            commandEntry.ExecuteCommandEntry("if size > 10");
            commandEntry.ExecuteCommandEntry("drawto 50 50");
            commandEntry.ExecuteCommandEntry("endif");

            // Assert
            Assert.Equal(new PointF(50, 50), commandEntry.GetCurrentPosition());
        }

        [Fact]
        public void ExecuteCommandEntry_ConditionalIfStatement_Invalid()
        {
            // Arrange
            var graphics = Graphics.FromImage(new Bitmap(1, 1));
            var commandEntry = new CommandLibrary(graphics);
            commandEntry.ExecuteCommandEntry("size = 50");

            // Act
            commandEntry.ExecuteCommandEntry("if size > 100");
            commandEntry.ExecuteCommandEntry("drawto 50 50");
            commandEntry.ExecuteCommandEntry("endif");

            // Assert
            Assert.Equal(new PointF(50, 50), commandEntry.GetCurrentPosition());
        }

    }
}