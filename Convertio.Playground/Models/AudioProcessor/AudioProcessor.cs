namespace Convertio.Playground.Models.AudioProcessor;

public abstract class AudioProcessor : IDisposable
{
  public void ProcessAudio(string inPath)
  {
    Console.WriteLine($"Streaming file: {inPath}");

    using var inStream = new FileStream(inPath, FileMode.Open, FileAccess.Read);

    try
    {
      PerformAudioConversion(inStream);
    }
    catch (Exception)
    {
      // Handle errors
      throw;
    }
  }

  public abstract void PerformAudioConversion(Stream stream);

  public void Dispose()
  {
    throw new NotImplementedException();
  }

  protected virtual void Dispose(bool disposing) { }
}

public class Mp3Processor : AudioProcessor
{
  public override void PerformAudioConversion(Stream stream)
  {
    // Process mp3...
  }
}

public class FlacProcessor : AudioProcessor
{
  public override void PerformAudioConversion(Stream stream)
  {
    // Process mp3...
  }
}