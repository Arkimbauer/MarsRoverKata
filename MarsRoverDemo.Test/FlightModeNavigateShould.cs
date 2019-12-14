using System.Collections.Generic;
using Xunit;

namespace MarsRoverDemo.Test
{
    public class FlightModeNavigateShould
    {
        private readonly MarsRover _marsRover;

        public FlightModeNavigateShould()
        {
            const double fuel = 8.0;
            var obstaclesList = new List<Axis> { new Axis(0, 1), new Axis(5, 0) };
            var obstacle = new ObstaclesList(obstaclesList);
            _marsRover = new MarsRover(new FLightModeNavigate(fuel, Compass.N, 0, 0,obstacle));
        }

        [Fact]
        public void TurnRightAndMoveOnePositionBeyondTheLimits()
        {
            var position = _marsRover.Execute("LLM");
            Assert.Equal("-1:0:W", position);   
        }

        [Fact]
        public void IsFuelIsEightDonNotMoveMoreThanFourPositionsAndInitializeGoHomeProcedure()
        {
            var position = _marsRover.Execute("MMMMMMMM");
            Assert.Equal("0:0:N", position);
        }

        [Fact]
        public void IfTheNextMovementIsOnAnObstacleDonNotMove()
        {
            var position =_marsRover.Execute("M");
            Assert.Equal("0:0:N", position);
        }
    }
}               