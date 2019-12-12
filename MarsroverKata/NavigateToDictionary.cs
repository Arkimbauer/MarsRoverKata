using System;
using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class NavigateToDictionary
    {
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
        
        public void NavigateTo(Compass compass, Axis axis)
        {
            _navigateTo[compass](axis);
        }
    }
}