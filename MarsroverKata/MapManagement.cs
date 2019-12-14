using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class MapManagement
    {
        private readonly ObstaclesList _obstaclesListList;
        private readonly MarsMap _marsMap;
        private readonly NavigateToDictionary _navigateToDictionary = new NavigateToDictionary();

        public MapManagement(ObstaclesList obstaclesListList, int width = 10, int height = 10)
        {
            _obstaclesListList = obstaclesListList;

            _marsMap = new MarsMap(width: width, height: height);
        }           
            
        public void NavigateTo(Direction direction, Axis axis)
        {
            var cloneAxis = axis.GiveMeAnAxisClone();
            _navigateToDictionary.NavigateTo(direction, cloneAxis);

            if (_marsMap.CheckIfAxisIsOnGridMap(cloneAxis) && CheckIfIsNotOnObstacleList(cloneAxis))
            {
                _navigateToDictionary.NavigateTo(direction, axis);
            }
        }

        private bool CheckIfIsNotOnObstacleList(Axis cloneAxis)
        {
            return _obstaclesListList == null || _obstaclesListList.CheckIfIsNotOnObstacleList(cloneAxis);
        }
    }
}   