using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;

namespace MarsRover;

public class NasaCommunicationProtocol
{
    public List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return commandsSequence
            .Select(char.ToString)
            .Select(commandRepresentation => CreateCommand(displacement, commandRepresentation))
            .ToList();
    }

    private Command CreateCommand(int displacement, string commandRepresentation)
    {
        switch (commandRepresentation)
        {
            case "l":
                return new RotationLeft();
            case "r":
                return new RotationRight();
            case "f":
                return new MovementForward(displacement);
            default:
                return new MovementBackward(displacement);
        }
    }
}