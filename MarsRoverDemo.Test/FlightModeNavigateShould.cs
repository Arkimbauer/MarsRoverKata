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
            _marsRover = new MarsRover(new FLightModeNavigate(fuel));
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
    }
}               