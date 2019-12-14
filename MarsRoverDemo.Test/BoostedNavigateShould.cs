using Xunit;

namespace MarsRoverDemo.Test
{
    public class BoostedNavigateShould
    {
        private readonly MarsRover _marsRover;

        public BoostedNavigateShould()
        {
            var boostedNavigate = new BoostedNavigate(Compass.N, 0, 0);
            _marsRover = new MarsRover(boostedNavigate);
        }

        [Fact]
        public void MoveTwoPositionsGivenOneMCommand()
        {
            var position = _marsRover.Execute("M");
            Assert.Equal("0:2:N", position);
        }

        [Fact]
        public void IfRobotAreOnePositionToLimitFieldMoveOnlyOneMovement()
        {
            var boostedNavigate = new BoostedNavigate(Compass.S, 0,1);
            var marsRover = new MarsRover(boostedNavigate);
            var position = marsRover.Execute("M");
            Assert.Equal("0:0:S", position);
        }
    }
}   