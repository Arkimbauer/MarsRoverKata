namespace MarsRoverDemo
{
    public class Axis
    {
        public int PositionY;
        public int PositionX;

        public Axis(int positionY, int positionX)
        {
            PositionY = positionY;
            PositionX = positionX;
        }

        public void MoveNorth()
        {
            PositionY++;
        }

        public void MoveEast()
        {
            PositionX++;
        }

        public void MoveSouth() 
        {
            PositionY--;
        }

        public void MoveWest()
        {
            PositionX--;
        }

        public void MoveNorthEast()
        {
            PositionX++;
            PositionY++;    
        }

        public void MoveSouthEast()
        {
            PositionX++;
            PositionY--;
        }

        public void MoveSouthWest()
        {
            PositionX--;
            PositionY--;
        }

        public void MoveNorthWest()
        {
            PositionX--;
            PositionY++;
        }

        public override string ToString()
        {
            return PositionX+":"+PositionY;
        }

        public Axis CloneAxis()
        {   
            var cloneAxis = new Axis(PositionY, PositionX);
            return cloneAxis;
        }

        protected bool Equals(Axis other)
        {
            return PositionY == other.PositionY && PositionX == other.PositionX;
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
                return (PositionY * 397) ^ PositionX;
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