using Convertio.AudioConverter.Models.AudioFile;


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

      return new AudioFile
      {
        FileName = file.Name,
        DurationMs = (long)file.Properties.Duration.TotalMilliseconds,
        FileSizeBytes = fileSizeBytes,
        AudioFormat = FromTaglibMimeType(file.MimeType)
      };
    }
    catch (TagLib.UnsupportedFormatException)
    {
      throw new NotSupportedException($"File format of {path} is not supported");
    }
  }

  private static AudioFormat FromTaglibMimeType(string mimeType) => mimeType.ToLower() switch
  {
    "taglib/mp3" => AudioFormat.MP3,
    "taglib/aac" => AudioFormat.AAC,
    "taglib/flac" => AudioFormat.FLAC,
    "taglib/wav" => AudioFormat.WAV,
    _ => throw new NotSupportedException($"{mimeType} is not supported.")
  };
}
