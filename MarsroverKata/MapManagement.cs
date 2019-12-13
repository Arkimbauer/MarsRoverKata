using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class MapManagement
    {
        private readonly Axis _obstacle;
        private readonly List<Axis> _gridPositions;
        private readonly NavigateToDictionary _navigateToDictionary = new NavigateToDictionary();

        public MapManagement(Axis obstacle = null, int width = 10, int height = 10)  
        {
            _obstacle = obstacle;
            var marsMap = new MarsMap(width: width, height: height);
            _gridPositions = marsMap.GiveMapGrid();
        }           
            
        public void NavigateTo(Direction direction, Axis axis)
        {
            var cloneAxis = axis.GiveMeAnAxisClone();
            _navigateToDictionary.NavigateTo(direction, cloneAxis);

            if (_gridPositions.Contains(cloneAxis) && _obstacle != cloneAxis)
            {
                _navigateToDictionary.NavigateTo(direction, axis);
            }
        }
    }
}   