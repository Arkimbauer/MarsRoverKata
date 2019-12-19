using MarsRoverDemo.Enums;
using MarsRoverDemo.PositionClass;

namespace MarsRoverDemo.StrategyPatterns
{
    public class FLightModeNavigate : INavigate
    {
        private readonly Direction _direction;
        private readonly Axis _axis;
        private readonly AirZoneManagement _airZoneManagement;

        public FLightModeNavigate(double fuel, Compass direction = 0, int positionX = 0, int positionY = 0, ObstaclesList obstaclesListList = null)
        {
            _axis = new Axis(positionX, positionY);
            _direction = new Direction(direction);
            _airZoneManagement = new AirZoneManagement(fuel, obstaclesListList);
        }

        public void Move()
        {
            _airZoneManagement.NavigateTo(_direction, _axis);
        }

        public void TurnRight() 
        {
            _direction.TurnRight();
        }
            
        public void TurnLeft()  
        {
            _direction.TurnLeft();
        }

        public override string ToString()
        {
            return $"{_axis}:{_direction}";
        }
    }
}