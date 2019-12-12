using Xunit;

namespace MarsRoverDemo.Test
{
    public class MarsRoverShould    
    {
        private readonly MarsRover _marsRover;
        private readonly MarsRover _marsRoverWithStartNavigate;
        private readonly MarsRover _marsRoverWithObstacleOnXOneYOne;

        public MarsRoverShould( )
        {
            var startNavigateWithObstacle = new Navigate(Compass.N, 0,0, new Axis(0, 1));
            _marsRoverWithObstacleOnXOneYOne = new MarsRover(startNavigateWithObstacle);

            _marsRover = new MarsRover();

            var startNavigate = new Navigate(Compass.N, 1, 1);
            _marsRoverWithStartNavigate = new MarsRover(startNavigate);
        }

        [Fact]
        public void StayInPlaceGivenNoCommand()
        {
            var result = _marsRover.Execute(string.Empty);
            Assert.Equal((string) "0:0:N", (string) result);
        }

        [Theory]
        [InlineData("0:1:N", "M")]
        [InlineData("0:2:N", "MM")]
        [InlineData("0:3:N", "MMM")]
        public void MoveAnyPositionsGivenCommandM(string expectedPosition, string command)
        {
            var position = _marsRover.Execute(command);
            Assert.Equal(expectedPosition, (string) position);
        }

        [Theory]
        [InlineData("0:0:E", "RR")]
        [InlineData("0:0:S", "RRRR")]
        [InlineData("0:0:W", "RRRRRR")]
        [InlineData("0:0:N", "RRRRRRRR")]
        public void TurnRightGivenCommandR(string expectedPosition, string command)
        {
            var position = _marsRover.Execute(command);
            Assert.Equal(expectedPosition, (string) position);
        }

        [Theory]
        [InlineData("0:0:W", "LL")]
        [InlineData("0:0:S", "LLLL")]
        [InlineData("0:0:E", "LLLLLL")]
        [InlineData("0:0:N", "LLLLLLLL")]
        public void TurnLeftGivenCommandL(string expectedPosition, string command)
        {
            var position = _marsRover.Execute(command);
            Assert.Equal(expectedPosition, (string) position);   
        }

        [Fact]
        public void TurnRightAndMoveOnePosition()
        {
            var position = _marsRover.Execute("RM");
            Assert.Equal((string) "1:1:NE", (string) position);
        }

        [Theory]
        [InlineData("1:2:N", "M")]
        [InlineData("2:2:NE", "RM")]
        [InlineData("2:1:E", "RRM")]
        [InlineData("2:0:SE", "RRRM")]
        [InlineData("1:0:S", "RRRRM")]
        [InlineData("0:2:NW", "LM")]
        [InlineData("0:1:W", "LLM")]
        [InlineData("0:0:SW", "LLLM")]
        public void MoveOnePositionForEachCompassDirection(string expectedPosition, string commands)
        {
            var position = _marsRoverWithStartNavigate.Execute(commands);
            Assert.Equal(expectedPosition, (string) position);
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
            Assert.Equal(expectedPosition, (string) position);
        }

        [Theory]
        [InlineData("0:2:NW", "LM")]
        [InlineData("2:2:NE", "RM")]
        [InlineData("2:0:SE", "RRRM")]
        [InlineData("0:0:SW", "LLLM")]
        public void MoveDiagonalIfYouAreOnDirectionNorthWestEastSouthAndRobotTurnLeftOrRightAndMove(string expectedPosition, string commands)
        {
            var position = _marsRoverWithStartNavigate.Execute(commands);
            Assert.Equal(expectedPosition, (string) position);
        }

        [Fact]
        public void IfTheNextMovementIsOnAnObstacleTurnRightMoveOneDirectionTurnLeftMoveTwoDirectionsTurnLeftMoveOneAndTurnRight()
        {
            var position = _marsRoverWithObstacleOnXOneYOne.Execute("M");
            Assert.Equal("0:2:N", position);
        }
    }
}   
                                