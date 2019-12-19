namespace MarsRoverDemo.StrategyPatterns
{
    public interface INavigate
    {
        void Move();
        void TurnRight();
        void TurnLeft();
        string ToString();
    }
}