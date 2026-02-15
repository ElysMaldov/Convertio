namespace Convertio.AudioConverter.Models.AudioFile;

/// <summary>
/// I use interface this since this is a data-only class and
/// no explicit hierarchy is required between different types of audio files.
/// </summary>
public interface IAudioFile
{
  string FileName { get; }
  AudioFormat AudioFormat { get; }
  long FileSizeBytes { get; }
  long DurationMs { get; set; }
}