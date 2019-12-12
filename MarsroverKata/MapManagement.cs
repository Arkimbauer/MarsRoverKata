using System;
using System.Collections.Generic;
using MarsRoverDemo;

namespace MarsRoverDemo
{
    public class MapManagement
    {
        private readonly Axis _obstacle;
        private readonly List<Axis> _gridPositions = new List<Axis>();
        private readonly NavigateToDictionary _navigateToDictionary = new NavigateToDictionary();

        public MapManagement(Axis obstacle = null)  
        {
            _obstacle = obstacle;
            const int width = 10;
            const int height = 10;
            var marsMap = new MarsMap(width: width, height: height);
            GenerateMapGridPositionsList(marsMap.Width, marsMap.Height);
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

        private void GenerateMapGridPositionsList(int width, int height)
        {
            var count = 0;
            for (var positionX = 0; positionX <= width; positionX++)
            {
                GeneratePositionYGrid(height, count);
                count++;
            }
        }

        private void GeneratePositionYGrid(int height, int count)
        {
            for (var positionY = 0; positionY <= height; positionY++)
            {
                _gridPositions.Add(new Axis(positionY, count));
            }
        }
    }
}   