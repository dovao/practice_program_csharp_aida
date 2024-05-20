using System.Collections.Generic;

namespace MarsRover;

public interface CommunicationProtocol
{
    List<Command> CreateCommands(string commandsSequence, int displacement);
}