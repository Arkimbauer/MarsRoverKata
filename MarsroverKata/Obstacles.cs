using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class Obstacles
    {
        private readonly List<Axis> _obstaclesList = new List<Axis>();

        public Obstacles(List<Axis> obstaclesList)
        {
            _obstaclesList = obstaclesList;
        }

        public bool CheckIfIsNotOnObstacleList(Axis cloneAxis)
        {
            return !_obstaclesList.Contains(cloneAxis);
        }
    }
}