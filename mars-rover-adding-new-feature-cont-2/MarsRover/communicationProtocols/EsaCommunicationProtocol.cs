using System.Collections.Generic;
using System.Linq;
using MarsRover.commands;

namespace MarsRover.communicationProtocols;

public class EsaCommunicationProtocol : CommunicationProtocol
{
    public List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return commandsSequence.Select(commandRepresentation => CreateCommand(displacement, commandRepresentation))
            .ToList();
    }

    private Command CreateCommand(int displacement, char commandRepresentation)
    {
        Command command;
        if (commandRepresentation == 'b')
            command = new MovementForward(displacement);
        else if (commandRepresentation == 'x')
            command = new MovementBackward(displacement);

        else if (commandRepresentation == 'f')
            command = new RotationLeft();
        else
            command = new RotationRight();

        return command;
    }
}