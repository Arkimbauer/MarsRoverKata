namespace MarsRoverDemo
{
    public class Axis
    {
        private int _positionY;
        private int _positionX;

        public Axis(int positionX, int positionY)
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
            MoveNorth();
            MoveEast();
        }

        public void MoveSouthEast()
        {
           MoveEast();
           MoveSouth();
        }

        public void MoveSouthWest()
        {
            MoveWest();
            MoveSouth();
        }

        public void MoveNorthWest()
        {
            MoveWest();
            MoveNorth();
        }

        public override string ToString()
        {
            return _positionX+":"+_positionY;
        }

        public Axis GiveMeAnAxisClone()
        {   
            var cloneAxis = new Axis(_positionX, _positionY);   
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