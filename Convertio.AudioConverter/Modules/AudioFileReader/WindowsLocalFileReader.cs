using Convertio.AudioConverter.Models.AudioFile;
using Convertio.AudioConverter.Modules.FileReader;

namespace Convertio.AudioConverter.Modules.AudioFileReader;

public class WindowsLocalAudioFileReader : IAudioFileReader
{
  public IAudioFile ReadFile(string path)
  {
    if (string.IsNullOrWhiteSpace(path))
    {
      throw new ArgumentException("Path is empty or has trailing whitespace");
    }

    try
    {
      // Use using to dispose TagLib.File that implements IDisposable
      using var file = TagLib.File.Create(path);

      return new WindowsLocalAudioFile
      {
        FileName = file.Name,
        DurationMs = (long)file.Properties.Duration.TotalMilliseconds,
        FileSizeBytes = file.Length,
        AudioFormat = AudioFormat.FromMimeType(file.MimeType)
      };
    }
    catch (TagLib.UnsupportedFormatException)
    {
      throw new NotSupportedException($"File format of {path} is not supported");
    }

  }
}
