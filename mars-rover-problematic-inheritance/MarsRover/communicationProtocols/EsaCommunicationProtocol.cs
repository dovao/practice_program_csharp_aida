using MarsRover.commands;
using MarsRover.communicationProtocols.commandExtractors;

namespace MarsRover.communicationProtocols;

public class EsaCommunicationProtocol : CommunicationProtocol
{
    public EsaCommunicationProtocol() : base(new FixedLengthCommandExtractor(1))
    {
    }

    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        return commandRepresentation switch
        {
            "b" => new MovementForward(displacement),
            "x" => new MovementBackward(displacement),
            "f" => new RotationLeft(),
            _ => new RotationRight()
        };
    }
}