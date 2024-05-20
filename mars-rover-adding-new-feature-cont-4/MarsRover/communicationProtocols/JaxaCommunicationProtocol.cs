using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractor;

namespace MarsRover.communicationProtocols;

public class JaxaCommunicationProtocol : CommunicationProtocol
{
    public JaxaCommunicationProtocol() : base(new JaxaCommandExtractor())
    {
    }

    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        if (commandRepresentation == "at") return new MovementBackward(displacement);

        if (commandRepresentation == "iz") return new RotationLeft();

        if (commandRepresentation == "der") return new RotationRight();

        return new MovementForward(displacement);
    }
}