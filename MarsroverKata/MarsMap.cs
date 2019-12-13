using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class MarsMap
    {
        private readonly int _width;
        private readonly int _height;
        private readonly List<Axis> _gridPositions = new List<Axis>();

        public MarsMap(int width, int height)
        {
            _width = width;
            _height = height;
            GenerateMapGridPositionsList();
        }

        private void GenerateMapGridPositionsList()
        {
            var positionXCount = 0;
            for (var positionX = 0; positionX <= _width; positionX++)
            {
                GeneratePositionYGrid(_height, positionXCount);
                positionXCount++;
            }
        }

        private void GeneratePositionYGrid(int height, int count)
        {
            for (var positionY = 0; positionY <= height; positionY++)
            {
                _gridPositions.Add(new Axis(positionY, count));
            }
        }

        public List<Axis> GiveMapGrid()
        {
            return _gridPositions;
        }
    }
}