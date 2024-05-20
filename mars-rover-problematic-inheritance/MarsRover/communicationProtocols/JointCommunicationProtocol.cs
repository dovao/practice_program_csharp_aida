using System;
using System.Collections.Generic;

namespace MarsRover.communicationProtocols;

public class JointCommunicationProtocol : CommunicationProtocol
{
    public JointCommunicationProtocol() : base(null)
    {
    }

    public override List<Command> CreateCommands(string commandsSequence, int displacement)
    {
        if (commandsSequence == string.Empty) return new List<Command>();
        var protocolIdentifier = commandsSequence.Substring(0, 1);
        var communicationProtocol = IdentifyCommunicationProtocol(protocolIdentifier);

        return communicationProtocol.CreateCommands(commandsSequence.Substring(1), displacement);
    }

    private CommunicationProtocol IdentifyCommunicationProtocol(string protocolIdentifier)
    {
        if (protocolIdentifier == "*") return new EsaCommunicationProtocol();

        if (protocolIdentifier == "%") return new CnsaCommunicationProtocol();

        if (protocolIdentifier == "+") return new JaxaCommunicationProtocol();

        if (protocolIdentifier == "$") return new NasaCommunicationProtocol();

        return new UnknownProtocol();
    }

    protected override Command CreateCommand(int displacement, string commandRepresentation)
    {
        throw new NotImplementedException();
    }
}