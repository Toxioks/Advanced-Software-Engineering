using System;
using System.Drawing;
using Xunit;
using ASEProject; 
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// This class provides Unit testing using the CommandParserTesting class, 
/// this class consists of unit tests for the CommandParser class in the ASEProject namespace.
/// </summary>

namespace ApplicationTesting
{
    public class CommandParserTesting
    {
        /// <summary>
        /// Verifies that CommandParser.IsValidCommandEntry correctly identifies a validated command.
        /// </summary>
        [Fact]
        public void IsValidCommandEntry_SuccessfulCommand()
        {
            // Arrange
            CommandParser parser = new CommandParser();

            // Act
            string validCommand = "moveto 510 150";
            bool isValid = parser.IsValidCommandEntry(validCommand);

            // Assert
            Assert.True(isValid);
        }

        /// <summary>
        /// Verifies that CommandParser.IsValidCommand identifies an invalid command and throws an InvalidCommandEntryException
        /// </summary>
        [Fact]
        public void IsValidCommandEntry_InvalidCommand()
        {
            // Arrange
            CommandParser parser = new CommandParser();

            // Act
            string invalidCommand = "False 510 150";

            //Assert
            Assert.Throws<InvalidCommandEntryException>(() =>
            {
                parser.IsValidCommandEntry(invalidCommand);
            });
        }

        [Fact]
        public void HasValidParameterEntry_Successfull()
        {
            // Arrange
            CommandParser parser = new CommandParser();

            // Act
            string validCommandEntry = "rectangle 55 55";

            // Assert
            bool hasValidParametersEntry = parser.HasValidParametersEntry(validCommandEntry);
            Assert.True(hasValidParametersEntry);
        }
    }
}