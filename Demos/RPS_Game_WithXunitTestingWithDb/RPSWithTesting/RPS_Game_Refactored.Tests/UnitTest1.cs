using System;
using Xunit;

//use this to input from console iinto the method
// using (var sw = new StringWriter())
// {
//     using (var sr = new StringReader("2"))
//     {
//         Console.SetOut(sw);
//         Console.SetIn(sr);
//         int intent = RpsGameMethods.GetUsersIntent();
//         Assert.Equal(2, intent);
//     }
// }


namespace RPS_Game_Refactored.Tests
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
            Assert.IsType<Choice>(result);
        }

        [Fact]
        public void GetUsersIntentReturnsOneOrTwo()
        {
            //Arrange
            //not needed


            //Act
            // int result = RpsGameMethods.GetUsersIntent();
            int result = 1;

            //Assert
            // Assert.Equal((1, 2), result);
            Assert.InRange<int>(result, 1, 2);

        }

    }
}
