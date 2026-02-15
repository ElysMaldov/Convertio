namespace Convertio.AudioConverter.Models.AudioFile;

public class LocalAudioFile : IAudioFile
{
  public required string FileName { get; init; }
  public required AudioFormat AudioFormat { get; init; }
  public long FileSizeBytes { get; init; }
  public long DurationMs { get; set; }
}