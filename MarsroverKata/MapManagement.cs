using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class MapManagement
    {
        private readonly Axis _obstacle;
        private List<Axis> _gridPositions;
        private readonly NavigateToDictionary _navigateToDictionary = new NavigateToDictionary();
        private readonly MarsMap _marsMap;

        public MapManagement(Axis obstacle = null, int width = 10, int height = 10)  
        {
            _obstacle = obstacle;
            _marsMap = new MarsMap(width: width, height: height);
            _gridPositions = _marsMap.GiveMapGrid();
        }           
            
        public void NavigateTo(Direction direction, Axis axis)
        {
            var cloneAxis = axis.GiveMeAnAxisClone();
            _navigateToDictionary.NavigateTo(direction, cloneAxis);

            if (_gridPositions.Contains(cloneAxis) && _obstacle != cloneAxis)
            {
                _navigateToDictionary.NavigateTo(direction, axis);
            }

            if (_gridPositions.Contains(cloneAxis) && _obstacle == cloneAxis)
            {
                GetAroundTheObstacle(direction, axis);
            }
        }

        private static void GetAroundTheObstacle(Direction direction, Axis axis)
        {
            direction.TurnRight();
            axis.MoveEast();
            direction.TurnLeft();
            axis.MoveNorth();
            axis.MoveNorth();
            direction.TurnLeft();
            axis.MoveWest();
            direction.TurnRight();
        }
    }
}   