using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class MapManagement
    {
        private readonly Axis _obstacle;
        private List<Axis> _gridPositions;
        private readonly NavigateToDictionary _navigateToDictionary = new NavigateToDictionary();
        private readonly MarsMap marsMap;

        public MapManagement(Axis obstacle = null)  
        {
            _obstacle = obstacle;
            const int width = 10;
            const int height = 10;
            marsMap = new MarsMap(width: width, height: height);
        }           
            
        public void NavigateTo(Direction direction, Axis axis)
        {
            _gridPositions = marsMap.GiveMapGrid();
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