using Xunit;

namespace MarsRoverDemo.Test
{
    public class FlightModeNavigateShould
    {
        private readonly MarsRover _marsRover;

        public FlightModeNavigateShould()
        {
            _marsRover = new MarsRover(new FLightModeNavigate());
        }

        [Fact]
        public void TurnRightAndMoveFivePositionsBeyondTheLimits()
        {
            var position = _marsRover.Execute("LLMMMMM");
            Assert.Equal("-5:0:W", position);
        }
    }
}