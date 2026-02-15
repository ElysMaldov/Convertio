namespace Convertio.AudioConverter.Models.AudioFile;

/// <summary>
/// Discrimintaed unions pattern that mimics Dart's sealed class and exshasutive switch.
///
/// Record (in this case it becomes record struct) is used to compare that 2
/// enums are the same value, instead of the same reference.
/// </summary>
public abstract record AudioFormat(string ExtensionLabel, string MimeType)
{
  // Init only allows setting this once during construction
  public required string ExtensionLabel { get; init; } = ExtensionLabel;
  public required string MimeType { get; init; } = MimeType;
}

// sealed stops other class from inheriting these further
public sealed record MP3() : AudioFormat("mp3", "audio/mpeg");
public sealed record AAC() : AudioFormat("aac", "audio/aac");
public sealed record FLAC() : AudioFormat("flac", "audio/flac");
public sealed record WAV() : AudioFormat("wav", "audio/wav");