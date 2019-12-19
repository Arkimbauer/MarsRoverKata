using System;
using System.Collections.Generic;
using MarsRoverDemo;

namespace MarsRoverDemo
{
    public class MarsRover
    {
        private readonly INavigate _navigate;
            
        public MarsRover(INavigate initialNavigate = null)
        {
            _navigate = initialNavigate ?? new Navigate(Compass.N, new Axis(0,0));
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
                _navigate.Move();

            if (command == Commands.Right)
                _navigate.TurnRight();

            if (command == Commands.Left)
                _navigate.TurnLeft();
        }
    }
}