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
