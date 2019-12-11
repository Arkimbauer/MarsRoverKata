using System.Collections.Generic;
using Xunit;

namespace MarsRoverDemo
{
    public class MarsRoverShould    
    {
        private readonly MarsRover _marsRover;

        public MarsRoverShould()
        {
            _marsRover = new MarsRover();
        }

        [Fact]
        public void StayInPlaceGivenNoCommand()
        {
            var result = _marsRover.Execute(string.Empty);
            Assert.Equal("0:0:N", result);
        }

        [Theory]
        [InlineData("0:1:N", "M")]
        [InlineData("0:2:N", "MM")]
        [InlineData("0:3:N", "MMM")]
        public void MoveAnyPositionsGivenCommandM(string expectedPosition, string command)
        {
            var position = _marsRover.Execute(command);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("0:0:E", "RR")]
        [InlineData("0:0:S", "RRRR")]
        [InlineData("0:0:W", "RRRRRR")]
        [InlineData("0:0:N", "RRRRRRRR")]
        public void TurnRightGivenCommandR(string expectedPosition, string command)
        {
            var position = _marsRover.Execute(command);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("0:0:W", "LL")]
        [InlineData("0:0:S", "LLLL")]
        [InlineData("0:0:E", "LLLLLL")]
        [InlineData("0:0:N", "LLLLLLLL")]
        public void TurnLeftGivenCommandL(string expectedPosition, string command)
        {
            var position = _marsRover.Execute(command);
            Assert.Equal(expectedPosition, position);   
        }

        [Fact]
        public void TurnRightAndMoveOnePosition()
        {
            var position = _marsRover.Execute("RRM");
            Assert.Equal("1:0:E", position);
        }

        [Theory]
        [InlineData("2:1:E", "RRM")]
        [InlineData("0:1:W", "LLM")]
        [InlineData("1:0:S", "RRRRM")]
        public void MoveOnePositionForEachCompassDirection(string expectedPosition, string commands)
        {
            var startNavigate = new Navigate(Compass.N, 1, 1);
            var marsRover = new MarsRover(startNavigate);
            var position = marsRover.Execute(commands);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("0:0:W", "LLM")]
        [InlineData("0:0:S", "RRRRM")]
        [InlineData("0:0:SW", "LLLM")]
        [InlineData("10:0:SE", "RRMMMMMMMMMMRM")]
        [InlineData("0:10:NW", "MMMMMMMMMMLM")]
        [InlineData("10:10:NE", "MMMMMMMMMMRRMMMMMMMMMMLM")]
        [InlineData("0:10:N", "MMMMMMMMMMM")]
        [InlineData("10:0:E", "RRMMMMMMMMMMM")]
        [InlineData("0:1:S", "RRMMMLLMMLLMMMMLLM")]
        public void DoNotMoveIfTheNextMoveYouWillBeOverTheField(string expectedPosition, string commands)
        {
            var position = _marsRover.Execute(commands);
            Assert.Equal(expectedPosition, position);
        }

        [Theory]
        [InlineData("0:2:NW", "LM")]
        [InlineData("2:2:NE", "RM")]
        [InlineData("2:0:SE", "RRRM")]
        [InlineData("0:0:SW", "LLLM")]
        public void MoveDiagonalIfYouAreOnDirectionNorthWestEastSouthAndRobotTurnLeftOrRightAndMove(string expectedPosition, string commands)
        {
            var startNavigate = new Navigate(Compass.N, 1, 1);
            var marsRover = new MarsRover(startNavigate);   
            var position = marsRover.Execute(commands);
            Assert.Equal(expectedPosition, position);
        }

    }
}   
                            