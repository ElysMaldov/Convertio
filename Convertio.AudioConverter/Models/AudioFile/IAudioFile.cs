namespace Convertio.AudioConverter.Models.AudioFile;

interface IAudioFile
{
  string FileName { get; }
  AudioFormat AudioFormat { get; }
  long FileSizeBytes { get; }
  long DurationMs { get; set; }
}