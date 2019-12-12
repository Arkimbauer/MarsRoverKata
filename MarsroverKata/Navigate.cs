namespace MarsRoverDemo
{
    public class Navigate
    {
        private readonly Direction _direction;
        private readonly Axis _axis;
        private readonly MapManagement _mapManagement;

        public Navigate(Compass direction, int positionY, int positionX)
        {
            _axis = new Axis(positionY, positionX);
            _direction = new Direction(direction);
            _mapManagement = new MapManagement();
        }    

        public void Move()
        {
            //_marsMap.NavigateTo(_direction._compass, _axis);
            
            if (_direction == new Direction(Compass.N))
            {
                _mapManagement.NavigateTo(Compass.N, _axis);
            }

            if (_direction == new Direction(Compass.NE))
            {
                _mapManagement.NavigateTo(Compass.NE, _axis);
            }

            if (_direction == new Direction(Compass.E))
            {
                _mapManagement.NavigateTo(Compass.E, _axis);
            }

            if (_direction == new Direction(Compass.SE))
            {
                _mapManagement.NavigateTo(Compass.SE, _axis);
            }
                
            if (_direction == new Direction(Compass.S))
            {
                _mapManagement.NavigateTo(Compass.S, _axis);
            }

            if (_direction == new Direction(Compass.SW))
            {
                _mapManagement.NavigateTo(Compass.SW, _axis);
            }

            if (_direction == new Direction(Compass.W))
            {
                _mapManagement.NavigateTo(Compass.W, _axis);
            }

            if (_direction == new Direction(Compass.NW))
            {
                _mapManagement.NavigateTo(Compass.NW, _axis);
            }   
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