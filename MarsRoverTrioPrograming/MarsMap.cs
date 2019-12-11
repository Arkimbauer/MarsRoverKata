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
        private readonly Dictionary<Compass, Action<Axis>> _navigateTo = new Dictionary<Compass, Action<Axis>>
        {
            {Compass.N, (axisToChange)=> { axisToChange.MoveNorth(); }},
            {Compass.NE, (axisToChange)=> { axisToChange.MoveNorthEast(); }},
            {Compass.E, (axisToChange)=> { axisToChange.MoveEast(); }},
            {Compass.SE, (axisToChange)=> { axisToChange.MoveSouthEast(); }},
            {Compass.S, (axisToChange)=> { axisToChange.MoveSouth(); }},
            {Compass.SW, (axisToChange)=> { axisToChange.MoveSouthWest(); }},
            {Compass.W, (axisToChange)=> { axisToChange.MoveWest(); }},
            {Compass.NW, (axisToChange)=> { axisToChange.MoveNorthWest(); }},
        };

        public MarsMap()
        {
            _width = 10;
            _height = 10;
            GenerateGridPositionsList(_width, _height);
        }

        public void NavigateTo(Compass compass, Axis axis)
        {
            var cloneAxis = axis.CloneAxis();

            _navigateTo[compass](cloneAxis);

            if (_gridPositions.Contains(cloneAxis))
            {
                _navigateTo[compass](axis);
            }
        }

        private void GenerateGridPositionsList(int width, int height)
        {
            var count = 0;
            for (int i = 0; i <= width; i++)
            {
                for (int y = 0; y <= width; y++)
                {
                    _gridPositions.Add(new Axis(count, y));
                }
                count++;
            }
        }
    }
}