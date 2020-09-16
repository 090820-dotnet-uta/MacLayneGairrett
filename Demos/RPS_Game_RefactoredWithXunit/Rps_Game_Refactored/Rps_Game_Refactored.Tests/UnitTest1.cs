using System;
using Xunit;
using Xunit.Abstractions;
using RPS_Game_Refactored;
using System.IO;

namespace Rps_Game_Refactored.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetRandomChoiceReturnsChoice()
        {
            // Arrange
            //not needed

            // Act
            Choice result = RpsGameMethods.GetRandomChoice();

            //Assert
            // Assert.Equals(Choice.Paper || Choice.Rock || Choice.Scissors, )
            Assert.IsType<Choice>(result);
        }

        [Fact]
        public void GetUsersIntentReturnOneOrTwo()
        {
            //Arrange
            //not needed


            //Act
           int result = RpsGameMethods.GetUsersIntent();

           //Assert
           using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("2"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    int intent = RpsGameMethods.GetUsersIntent();
                    Assert.Equal(2, intent);
                }
            }
        
        }

    }
}
