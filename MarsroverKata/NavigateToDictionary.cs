using System;
using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class NavigateToDictionary
    {
        private readonly Dictionary<Direction, Action<Axis>> _navigateTo = new Dictionary<Direction, Action<Axis>>
        {
            {new Direction(Compass.N), (axisToChange)=> { axisToChange.MoveNorth(); }},
            {new Direction(Compass.NE), (axisToChange)=> { axisToChange.MoveNorthEast(); }},
            {new Direction(Compass.E), (axisToChange)=> { axisToChange.MoveEast(); }},
            {new Direction(Compass.SE), (axisToChange)=> { axisToChange.MoveSouthEast(); }},
            {new Direction(Compass.S), (axisToChange)=> { axisToChange.MoveSouth(); }},
            {new Direction(Compass.SW), (axisToChange)=> { axisToChange.MoveSouthWest(); }},
            {new Direction(Compass.W), (axisToChange)=> { axisToChange.MoveWest(); }},
            {new Direction(Compass.NW), (axisToChange)=> { axisToChange.MoveNorthWest(); }},
        };
        
        public void NavigateTo(Direction direction, Axis axis)
        {
            _navigateTo[direction](axis);
        }
    }
}