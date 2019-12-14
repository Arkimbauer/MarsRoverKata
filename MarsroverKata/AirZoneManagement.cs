using System;
using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class AirZoneManagement
    {
        private double _fuel;
        private readonly ObstaclesList _obstaclesListList;
        private readonly NavigateToDictionary _navigateToDictionary = new NavigateToDictionary();
        private double _fuelToReturnHome;
        private List<Direction> _wayBack = new List<Direction>();

        public AirZoneManagement(double fuel, ObstaclesList obstaclesListList)
        {
            _fuel = fuel;
            _obstaclesListList = obstaclesListList;
            CalculateFuelToReturnHome();
        }

        public void NavigateTo(Direction direction, Axis axis)  
        {
            const double empty = 0.0;
            if (_fuel == empty)
            {
                return;
            }

            if (_fuel > _fuelToReturnHome)
            {
                _navigateToDictionary.NavigateTo(direction, axis);
                _fuel --;
                _wayBack.Add(direction);
            }

            if (_fuel <= _fuelToReturnHome)
            {
                Turn180(direction);
                GoHome(axis);
                Turn180(direction);
            }
        }

        private void GoHome(Axis axis)
        {
            foreach (var direction in _wayBack)
            {   
                _navigateToDictionary.NavigateTo(direction, axis);
                _fuel--;
            }
        }

        private void CalculateFuelToReturnHome()
        {
            _fuelToReturnHome = _fuel / 2 + _fuel % 2;
        }

        private static void Turn180(Direction direction)
        {
            direction.TurnRight();
            direction.TurnRight();
            direction.TurnRight();
            direction.TurnRight();
        }
    }
}