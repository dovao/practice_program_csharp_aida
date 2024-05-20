using System.Collections.Generic;

namespace MarsRover.communicationProtocols;

public interface CommandExtractor
{
    List<string> Extract(string commandsSequence);
}