# cs-mel-spectrogram

Convert audio file to melgram (that is, me-spectrogram) in .NET 

Note that this is a x64 build, therefore your .NET project must be also x64 build.

# Install

Run the following nuget command to install:

```bash
Install-Package cs-mel-spectrogram
```

# Usage

The sample code below shows how to use the MelGram to convert an (any) audio file to a mel-spectrogram image:

```cs 
using System;
using System.Drawing;
using System.IO;

namespace MelGram
{
    class Program
    {
        static void Main(string[] args)
        {
            MelSpectrogram gram = new MelSpectrogram();
            string dataDirPath = Path.Combine(IOUtils.AssemblyDirectory, "..", "..", "..", "..", "gtzan", "genres");
            if (!Directory.Exists(dataDirPath))
            {
                Console.WriteLine("{0} does not exists", dataDirPath);
                return;
            }

            string[] subDirectories = Directory.GetDirectories(dataDirPath);
            foreach (string subDirectory in subDirectories)
            {
                string[] files = Directory.GetFiles(subDirectory, "*.au");
                foreach (string file in files)
                {
                    Console.WriteLine("Converting: {0}", file);
                    Bitmap img = gram.Convert(file, 48);
                    img.Save(file + ".png");
                }

            }
        }
    }
}
```
