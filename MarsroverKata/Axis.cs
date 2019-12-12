namespace MarsRoverDemo
{
    public class Axis
    {
        private int _positionY;
        private int _positionX;

        public Axis(int positionY, int positionX)
        {
            _positionY = positionY;
            _positionX = positionX;
        }

        public void MoveNorth()
        {
            _positionY++;
        }

        public void MoveEast()
        {
            _positionX++;
        }

        public void MoveSouth() 
        {
            _positionY--;
        }

        public void MoveWest()
        {
            _positionX--;
        }

        public void MoveNorthEast()
        {
            _positionX++;
            _positionY++;    
        }

        public void MoveSouthEast()
        {
            _positionX++;
            _positionY--;
        }

        public void MoveSouthWest()
        {
            _positionX--;
            _positionY--;
        }

        public void MoveNorthWest()
        {
            _positionX--;
            _positionY++;
        }

        public override string ToString()
        {
            return _positionX+":"+_positionY;
        }

        public Axis CloneAxis()
        {   
            var cloneAxis = new Axis(_positionY, _positionX);
            return cloneAxis;
        }

        private bool Equals(Axis other)
        {
            return _positionY == other._positionY && _positionX == other._positionX;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Axis)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_positionY * 397) ^ _positionX;
            }
        }

        public static bool operator ==(Axis left, Axis right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Axis left, Axis right)
        {
            return !Equals(left, right);
        }
    }
}   