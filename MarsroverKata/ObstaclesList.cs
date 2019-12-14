using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class ObstaclesList
    {
        private readonly List<Axis> _obstaclesList;

        public ObstaclesList(List<Axis> obstaclesList)
        {
            _obstaclesList = obstaclesList;
        }

        public bool CheckIfIsNotOnObstacleList(Axis cloneAxis)
        {
            return !_obstaclesList.Contains(cloneAxis);
        }
    }
}   