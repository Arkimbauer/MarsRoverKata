using System;
using System.Collections.Generic;
using MarsRoverDemo;

namespace MarsRoverDemo
{
    public class MapManagement
    {
        private readonly List<Axis> _gridPositions = new List<Axis>();
        private readonly NavigateToDictionary _navigateToDictionary = new NavigateToDictionary();

        public MapManagement()
        {
            var marsMap = new MarsMap(width: 10, height: 10);
            GenerateMapGridPositionsList(marsMap.Width, marsMap.Height);
        }

        public void NavigateTo(Compass compass, Axis axis)
        {
            var cloneAxis = axis.CloneAxis();
            
            _navigateToDictionary.NavigateTo(compass, cloneAxis);

            if (_gridPositions.Contains(cloneAxis))
            {
                _navigateToDictionary.NavigateTo(compass, axis);
            }
        }

        private void GenerateMapGridPositionsList(int width, int height)
        {
            var count = 0;
            for (int positionX = 0; positionX <= width; positionX++)
            {
                GeneratePositionYGrid(height, count);
                count++;
            }
        }

        private void GeneratePositionYGrid(int height, int count)
        {
            for (int positionY = 0; positionY <= height; positionY++)
            {
                _gridPositions.Add(new Axis(count, positionY));
            }
        }
    }
}   