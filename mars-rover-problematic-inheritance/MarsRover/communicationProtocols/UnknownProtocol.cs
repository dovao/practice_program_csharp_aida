using System;
using System.Collections.Generic;

namespace MarsRover.communicationProtocols;

internal class UnknownProtocol : CommunicationProtocol
{
    public UnknownProtocol() : base(null)
    {
    }

    public override List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        return new List<Command>();
    }

    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        throw new NotImplementedException();
    }
}