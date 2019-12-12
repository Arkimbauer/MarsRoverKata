using System.Collections.Generic;

namespace MarsRoverDemo
{
    public class MarsMap
    {   
        public readonly int Width;
        public readonly int Height;
        private readonly List<Axis> _gridPositions = new List<Axis>();

        public MarsMap(int width, int height)
        {
            Width = width;
            Height = height;
            GenerateMapGridPositionsList();
        }

        private void GenerateMapGridPositionsList()
        {
            var count = 0;
            for (var positionX = 0; positionX <= Width; positionX++)
            {
                GeneratePositionYGrid(Height, count);
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

        public List<Axis> GiveMapGrid()
        {
            return _gridPositions;
        }
    }
}