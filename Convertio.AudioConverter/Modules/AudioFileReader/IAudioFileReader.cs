using Convertio.AudioConverter.Models.AudioFile;

namespace Convertio.AudioConverter.Modules.AudioFileReader;

public interface IAudioFileReader
{
  public IAudioFile ReadFile(string path);
}
