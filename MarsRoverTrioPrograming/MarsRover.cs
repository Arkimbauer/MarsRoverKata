using System;
using System.Collections.Generic;
using MarsRoverDemo;

namespace MarsRoverDemo
{
    public class MarsRover
    {
        private readonly Navigate _navigate;
            
        public MarsRover(Navigate initialNavigate = null)
        {
            _navigate = initialNavigate ?? new Navigate(Compass.N, positionX:0, positionY:0);
        }
            
        public string Execute(string textCommands)
        {   
            foreach (var command in textCommands)
            {
                ExecuteCommand(CommandFactory.GenerateCommandFromText(command));
            }

            return _navigate.ToString();
        }

        private void ExecuteCommand(Commands command)
        {
            if (command == Commands.Move)
            {   
                _navigate.Move();
            }

            if (command == Commands.Right)
            {
                _navigate.TurnRight();
            }

            if (command == Commands.Left)
            {
                _navigate.TurnLeft();
            }
        }
    }
}