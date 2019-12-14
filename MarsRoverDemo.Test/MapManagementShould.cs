using System.Collections.Generic;
using Xunit;
            
namespace MarsRoverDemo.Test
{
    public class MapManagementShould
    {
        private readonly MarsRover _marsRoverWithObstacleOnXZeroYOne;

        public MapManagementShould()
        {
            var obstaclesList = new List<Axis>{new Axis(0,1), new Axis(5, 0) };
            var obstacle = new ObstaclesList(obstaclesList);
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
            var position = _marsRoverWithObstacleOnXZeroYOne.Execute("MRRMMMMMMM");
            Assert.Equal("4:0:E", position);
        }
    }
}       