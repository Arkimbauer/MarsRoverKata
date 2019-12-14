namespace MarsRoverDemo
{
    public class AirZoneManagement
    {
        private readonly ObstaclesList _obstaclesListList;
        private readonly NavigateToDictionary _navigateToDictionary = new NavigateToDictionary();

        public AirZoneManagement(ObstaclesList obstaclesListList)
        {
            _obstaclesListList = obstaclesListList;
        }

        public void NavigateTo(Direction direction, Axis axis)  
        {
            _navigateToDictionary.NavigateTo(direction, axis);
        }
    }
}