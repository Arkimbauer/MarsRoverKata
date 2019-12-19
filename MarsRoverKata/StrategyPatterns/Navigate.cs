using MarsRoverDemo.Enums;
using MarsRoverDemo.PositionClass;

namespace MarsRoverDemo.StrategyPatterns
{
    public class Navigate : INavigate
    {
        private readonly Direction _direction;
        private readonly Axis _axis;
        private readonly MapManagement _mapManagement;

        public Navigate(Compass direction, Axis axis, ObstaclesList obstaclesListList = null)
        {
            _axis = axis;
            _direction = new Direction(direction);
            _mapManagement = new MapManagement(obstaclesListList);
        }       

        public void Move()
        {
            _mapManagement.NavigateTo(_direction, _axis);
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