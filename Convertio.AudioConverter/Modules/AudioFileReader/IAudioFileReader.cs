using Convertio.AudioConverter.Models.AudioFile;

namespace Convertio.AudioConverter.Modules.FileReader;

public interface IAudioFileReader
{
  public IAudioFile ReadFile(string path);
}
