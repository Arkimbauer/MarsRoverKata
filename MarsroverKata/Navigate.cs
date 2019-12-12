namespace MarsRoverDemo
{
    public class Navigate
    {
        private readonly Direction _direction;
        private readonly Axis _axis;
        private readonly MapManagement _mapManagement;

        public Navigate(Compass direction, int positionY, int positionX)
        {
            _axis = new Axis(positionX, positionY);
            _direction = new Direction(direction);
            _mapManagement = new MapManagement();
        }    

        public void Move()
        {
            _mapManagement.NavigateTo(_direction.CurrentCompass(), _axis);
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