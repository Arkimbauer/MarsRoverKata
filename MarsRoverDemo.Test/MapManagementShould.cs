using System.Collections.Generic;
using Xunit;
            
namespace MarsRoverDemo.Test
{
    public class MapManagementShould
    {
        private readonly MarsRover _marsRoverWithObstacleOnXZeroYOne;

        public MapManagementShould()
        {
            var obstaclesList = new List<Axis>{new Axis(0,1)};
            var obstacle = new Obstacles(obstaclesList);
            var startNavigateWithObstacle = new Navigate(Compass.N, 0, 0, obstacle);
            _marsRoverWithObstacleOnXZeroYOne = new MarsRover(startNavigateWithObstacle);
        }

        [Fact]
        public void IfTheNextMovementIsOnAnObstacleDonNotMove()
        {
            var position = _marsRoverWithObstacleOnXZeroYOne.Execute("M");
            Assert.Equal("0:0:N", position);
        }

        [Fact]
        public void IfTheNextMovementIsOnAnObstacleDonNotMoveThenTurnLeftAndMoveTwoTimes()
        {
            var position = _marsRoverWithObstacleOnXZeroYOne.Execute("MRRMM");
            Assert.Equal("2:0:E", position);
        }

        [Fact]
        public void DonNotMoveIfOnNextNorthYPositionThereIsAnObstacleAndTurnRightThenDonNotMoveAgainIfOnTheEastPositionThereIsAnotherObstacle()
        {
            var obstaclesList = new List<Axis> {new Axis(0, 1), new Axis(1,0)};
            var obstacles = new Obstacles(obstaclesList);
            var startNavigateWithTwoObstacles = new Navigate(Compass.N, 0,0, obstacles);
            var marsRover = new MarsRover(startNavigateWithTwoObstacles);
            var position = marsRover.Execute("MRRM");
            Assert.Equal("0:0:E", position);
        }
    }
}       