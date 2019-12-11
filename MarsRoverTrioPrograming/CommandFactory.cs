namespace MarsRoverDemo
{
    public static class CommandFactory
    {
        private const char MoveCommand = 'M';
        private const char TurnLeftCommand = 'L';

        public static Commands GenerateCommandFromText(char charCommand)
        {
            if (charCommand == MoveCommand)
            {
                return Commands.Move;
            }

            if (charCommand == TurnLeftCommand)
            {
                return Commands.Left;
            }
            
            return Commands.Right;
        }
    }
}