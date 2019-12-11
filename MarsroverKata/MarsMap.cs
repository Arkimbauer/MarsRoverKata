using System;
using System.Collections.Generic;
using MarsRoverDemo;

namespace MarsRoverDemo
{
    public class MarsMap
    {
        private readonly int _width;
        private readonly int _height;
        private readonly List<Axis> _gridPositions = new List<Axis>();

        public MarsMap()
        {
            _width = 10;
            _height = 10;
            GenerateGridPositionsList(_width, _height);
        }

        public void NavigateTo(Compass compass, Axis axis)
        {
            var cloneAxis = axis.CloneAxis();

            new NavigateToDictionary(compass, cloneAxis);

            if (_gridPositions.Contains(cloneAxis))
            {
                new NavigateToDictionary(compass, axis);
            }
        }

        private void GenerateGridPositionsList(int width, int height)
        {
            var count = 0;
            for (int positionX = 0; positionX <= width; positionX++)
            {
                GeneratePositionYGrid(width, count);
                count++;
            }
        }

        private void GeneratePositionYGrid(int width, int count)
        {
            for (int positionY = 0; positionY <= width; positionY++)
            {
                _gridPositions.Add(new Axis(count, positionY));
            }
        }
    }
}   