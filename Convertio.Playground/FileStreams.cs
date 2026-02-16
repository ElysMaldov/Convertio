// See https://aka.ms/new-console-template for more information

using System.Text;

string path = @"C:\Users\emuia\programming\learning\csharp\Convertio\Convertio.Playground\example.txt";

// Read file
if (File.Exists(path))
{
  // string content = File.ReadAllText(path);

  // Console.WriteLine("File contents:");
  // Console.WriteLine(content);

  // string newContent = "Saikai";
  // File.WriteAllText(path, newContent);
  // File.AppendAllText(path, "\nI should take my meds");

  string directoryPath = @"C:\Users\emuia\programming\learning\csharp\Convertio\Convertio.Playground\NewDir";
  // string filePath = Path.Combine(directoryPath, "Meow.txt");

  // if (!Directory.Exists(directoryPath))
  // {
  //   Directory.CreateDirectory(directoryPath);
  // }

  // if (!File.Exists(filePath))
  // {
  //   File.WriteAllText(filePath, "New Meow file");
  // }

  string largeFilePath = @"C:\Users\emuia\Downloads\big.txt";

  // using (FileStream fs = new(Path.Combine(directoryPath, "StreamedFile.txt"), FileMode.Create))
  // {
  //   byte[] data = Encoding.UTF8.GetBytes("Write me hereee with emojis bcs im UTF8 💯💯💯");
  //   fs.Write(data, 0, data.Length);
  // }

  // This defeats the purpsoe of streams since byte[fs.length] loads an array as big as the memory and ReadExactly dumps everything in
  // to memory anyways
  // using (FileStream fs = new(largeFilePath, FileMode.Open))
  // {
  //   byte[] buffer = new byte[fs.Length];
  //   fs.ReadExactly(buffer);
  //   Console.WriteLine(Encoding.UTF8.GetString(buffer));
  // }

  // Using smaller buffers and while loop to actually chunk the reads with streams
  using (FileStream fs = new(largeFilePath, FileMode.Open))
  {
    byte[] buffer = new byte[4096];
    int bytesRead;

    // Assign bytesRead as much as 4096 until we run out of bytes to read
    // We only get as much bytes from the file as buffer.Length, so we chunk the file
    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
    {
      // Decode and print out a chunk of the bytes from our file
      Console.Write(Encoding.UTF8.GetString(buffer, 0, bytesRead));
    }
  }
}
else
{
  Console.WriteLine("File not found.");
}



// public IEnumerable<string> GetFileChunks(string path)
// {
//   using var fs = new FileStream(path, FileMode.Open);
//   byte[] buffer = new byte[1024]; // Small buffer for that "petite" energy
//   int bytesRead;

//   while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
//   {
//     string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);

//     // This is the magic! The code "pauses" here.
//     // It hands the 'chunk' to the caller and then... STOPS.
//     yield return chunk;

//     // When the caller asks for the next item, the code wakes up
//     // right here and continues the loop!
//   }
// }

// // --- How you actually use it in your main code ---

// foreach (string piece in GetFileChunks("huge_manifesto.txt"))
// {
//   Console.WriteLine("--- New Chunk Received ---");
//   Console.Write(piece);

//   // Now YOU have the power to pause between each "yielded" item
//   Thread.Sleep(2000);
// }