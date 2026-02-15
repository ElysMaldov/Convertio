namespace Convertio.AudioConverter.Models.AudioFile;

/// <summary>
/// Discrimintaed unions pattern that mimics Dart's sealed class and exshasutive switch.
///
/// Record (in this case it becomes record struct) is used to compare that 2
/// enums are the same value, instead of the same reference.
/// </summary>
public abstract record AudioFormat(string ExtensionLabel, string MimeType)
{
  public static AudioFormat FromTaglibMimeType(string mimeType) => mimeType.ToLower() switch
  {
    "taglib/mp3" => new MP3(),
    "taglib/aac" => new AAC(),
    "taglib/flac" => new FLAC(),
    "taglib/wav" => new WAV(),
    _ => throw new NotSupportedException($"{mimeType} is not supported.")
  };
}

// sealed stops other class from inheriting these further
public sealed record MP3() : AudioFormat("mp3", "audio/mpeg");
public sealed record AAC() : AudioFormat("aac", "audio/aac");
public sealed record FLAC() : AudioFormat("flac", "audio/flac");
public sealed record WAV() : AudioFormat("wav", "audio/wav");