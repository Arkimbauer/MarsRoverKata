using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class MarsMap
    {
        private readonly List<Axis> _gridPositions = new List<Axis>();

        public MarsMap(int width, int height)
        {
            GenerateMapGridPositionsList(width, height);
        }

        private void GenerateMapGridPositionsList(int width, int height)
        {
            var positionXCount = 0;
            for (var positionX = 0; positionX <= width; positionX++)
            {
                GeneratePositionYGrid(height, positionXCount);
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