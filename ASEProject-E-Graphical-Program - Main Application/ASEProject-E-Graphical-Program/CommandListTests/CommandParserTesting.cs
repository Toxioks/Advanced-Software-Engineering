using System;
using System.Drawing;
using Xunit;
using ASEProject; 
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using static ASEProject.Form1;

/// <summary>
/// This class provides Unit testing using the CommandParserTesting class, 
/// this class consists of unit tests for the CommandParser class in the ASEProject namespace.
/// </summary>

namespace ApplicationTesting
{
    public class CommandParserTesting
    {
        /// <summary>
        /// Verifies that <see cref="CommandParser.IsValidCommandEntry"/> correctly identifies a validated command.
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
        /// Verifies that <see cref="CommandParser.IsValidCommandEntry"/> identifies an invalid command and throws an InvalidCommandEntryException
        /// </summary>
        [Fact]
        public void IsValidCommandEntry_InvalidCommand()
        {
            // Arrange
            CommandParser parser = new CommandParser();

            // Act
            string invalidCommand = "False 510 150";

            //Assert
            Assert.Throws<CustomInvalidCommandEntryException>(() =>
            {
                parser.IsValidCommandEntry(invalidCommand);
            });
        }

        /// <summary>
        /// Verifies that <see cref="CommandParser.HasValidParametersEntry"/> identifies an valid parameter entry.
        ///  </summary>
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

        /// <summary>
        /// Verifies that <see cref="CommandParser.HasValidParametersEntry"/> identifies an invalid parameter entry.
        ///  </summary>
        [Fact]
        public void HasValidParameterEntry_Failure()
        {
            // Arrange
            CommandParser parser = new CommandParser();

            // Act
            string validCommandEntry = "rectangle fail fail";

            // Assert
            Assert.Throws<CustomInvalidCommandEntryException>(() =>
            {
                parser.HasValidParametersEntry(validCommandEntry);
            });
        }

        /// <summary>
        /// Test's if the CommandParser can successfully parse a valid variable replacement.
        [Fact]
        public void VariableNameReplacement_Successful_Replacement()
        {
            // Arrange
            CommandParser parser = new CommandParser();
            CommandLibrary commandEntryList = new CommandLibrary(null);

            // Act
            commandEntryList.Variable("x", 50);
            string firstVariable = "circle x";
            string secondVariable = parser.VariableNameReplacement(firstVariable, commandEntryList);

            // Assert
            Assert.Equal("circle 50", secondVariable);
        }

        /// <summary>
        /// Test's if the CommandParser can successfully parse a valid conditional command entry.
        /// </summary>
        [Fact]
        public void ConditionalCommand_Successful_IfStatement()
        {
            // Arrange
            CommandParser parser = new CommandParser();

            // Act
            string validCommandEntry = "if 5 > 1";

            // Assert
            Assert.True(parser.ConditionalCommand(validCommandEntry));
        }

        /// <summary>
        /// Test's if the CommandParser can successfully parse a valid loop command entry.
        /// </summary>
        [Fact] 
        public void CommandLoop_Successful_LoopStatement()
        {
            // Arrange
            CommandParser parser = new CommandParser();

            // Act
            string validCommandEntry = "loop 5";

            // Assert
            Assert.True(parser.CommandLoop(validCommandEntry));
        }

        /// <summary>
        ///  Test's if the CommandParser can successfully parse a valid variable expression command entry.
        /// </summary>
        [Fact]
        public void VariableIsDeclaredOrMathmatic_Successful_ValidExpression()
        {
            // Arrange
            CommandParser parser = new CommandParser();

            // Act
            string validCommandEntry = "x = 10 + 10";

            // Assert
            Assert.True(parser.VariableIsDeclaredOrMathmatic(validCommandEntry));
        }

        /// <summary>
        /// Test's if the CommandParser can successfully parse a valid variable declaration command entry.
        /// </summary>
        [Fact]
        public void VariableIsDeclraed_Successful_ValidDeclration()
        {
            // Arrange
            CommandParser parser = new CommandParser();

            // Act
            string validCommandEntry = "x = 100";

            // Assert
            Assert.True(parser.VariableIsDeclaredOrMathmatic(validCommandEntry));
        }
    }
}