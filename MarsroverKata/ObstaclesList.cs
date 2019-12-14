using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class ObstaclesList
    {
        private readonly List<Axis> _obstaclesList;
        private readonly ObstacleType _obstacleType;

        public ObstaclesList(List<Axis> obstaclesList, ObstacleType obstacleType)
        {
            _obstaclesList = obstaclesList;
            _obstacleType = obstacleType;
        }

        public bool CheckTypeObstacle(ObstacleType expectedObstacleType)
        {
            return expectedObstacleType == _obstacleType;
        }

        public bool CheckIfIsNotOnObstacleList(Axis cloneAxis)  
        {   
            return !_obstaclesList.Contains(cloneAxis);
        }
    }
}   