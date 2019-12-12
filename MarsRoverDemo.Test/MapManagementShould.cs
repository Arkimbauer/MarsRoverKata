using Xunit;

namespace MarsRoverDemo.Test
{
    public class MapManagementShould
    {
        private readonly MarsRover _marsRoverWithObstacleOnXOneYOne;

        public MapManagementShould( )
        {
            var startNavigateWithObstacle = new Navigate(Compass.N, 0, 0, new Axis(0, 1));
            _marsRoverWithObstacleOnXOneYOne = new MarsRover(startNavigateWithObstacle);
        }

        [Fact]
        public void IfTheNextMovementIsOnAnObstacleTurnRightMoveOneDirectionTurnLeftMoveTwoDirectionsTurnLeftMoveOneAndTurnRight()
        {
            var position = _marsRoverWithObstacleOnXOneYOne.Execute("M");
            Assert.Equal("0:2:N", position);
        }
    }
}   