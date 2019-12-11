namespace MarsRoverDemo
{
    public class Direction
    {
        private Compass _compass;

        public Direction(Compass compass)
        {
            _compass = compass;
        }

        public void TurnRight()
        {
            if (_compass == Compass.NW)
            {
                _compass = Compass.N;
                return;
            }

            _compass++;
        }

        public void TurnLeft()
        {
            if (_compass == Compass.N)
            {
                _compass = Compass.NW;
                return;
            }

            _compass--;
        }

        public override string ToString()
        {
            return _compass.ToString();
        }

        protected bool Equals(Direction other)
        {
            return _compass == other._compass;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Direction)obj);
        }

        public override int GetHashCode()
        {
            return (int)_compass;
        }

        public static bool operator ==(Direction left, Direction right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Direction left, Direction right)
        {
            return !Equals(left, right);
        }
    }
}