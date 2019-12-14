using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class Navigate : INavigate
    {
        private readonly Direction _direction;
        private readonly Axis _axis;
        private readonly MapManagement _mapManagement;

        public Navigate(Compass direction, int positionX, int positionY, ObstaclesList obstaclesListList = null)
        {
            _axis = new Axis(positionX, positionY);
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