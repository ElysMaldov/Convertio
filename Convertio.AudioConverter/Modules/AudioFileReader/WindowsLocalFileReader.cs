using System.Runtime.InteropServices.Marshalling;
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
      // We use a seperate FileInfo to actually get the size, TagLib doesn't provide this
      long fileSizeBytes = new FileInfo(path).Length;
      // Use using to dispose TagLib.File that implements IDisposable
      using var file = TagLib.File.Create(path);

      return new WindowsLocalAudioFile
      {
        FileName = file.Name,
        DurationMs = (long)file.Properties.Duration.TotalMilliseconds,
        FileSizeBytes = fileSizeBytes,
        AudioFormat = AudioFormat.FromTaglibMimeType(file.MimeType)
      };
    }
    catch (TagLib.UnsupportedFormatException)
    {
      throw new NotSupportedException($"File format of {path} is not supported");
    }
  }
}
