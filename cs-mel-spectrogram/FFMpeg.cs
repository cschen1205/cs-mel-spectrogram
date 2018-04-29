using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelGram
{
    public class FFMpeg
    {
        public static void InstallFFMpeg()
        {
            InstallBinaryFile("avcodec-58.dll", Properties.Resources.avcodec_58);
            InstallBinaryFile("avdevice-58.dll", Properties.Resources.avdevice_58);
            InstallBinaryFile("avfilter-7.dll", Properties.Resources.avfilter_7);
            InstallBinaryFile("avformat-58.dll", Properties.Resources.avformat_58);
            InstallBinaryFile("avutil-56.dll", Properties.Resources.avutil_56);
            InstallBinaryFile("ffmpeg.exe", Properties.Resources.ffmpeg);
            InstallBinaryFile("ffplay.exe", Properties.Resources.ffplay);
            InstallBinaryFile("ffprobe.exe", Properties.Resources.ffprobe);
            InstallBinaryFile("postproc-55.dll", Properties.Resources.postproc_55);
            InstallBinaryFile("swresample-3.dll", Properties.Resources.swresample_3);
            InstallBinaryFile("swscale-5.dll", Properties.Resources.swscale_5);
        }

        private static void InstallBinaryFile(string filename, byte[] bytes)
        {
            string path = Path.Combine(IOUtils.AssemblyDirectory, filename);
            if (File.Exists(path)) return;
            File.WriteAllBytes(path, bytes);
        }

        public static void Convert2Mp3(string source, string target)
        {
            InstallFFMpeg();

            string executablePath = Path.Combine(IOUtils.AssemblyDirectory, "ffmpeg.exe");

            var info = new ProcessStartInfo();
            info.FileName = string.Format("\"{0}\"", executablePath);
            info.WorkingDirectory = IOUtils.AssemblyDirectory;
            info.Arguments = string.Format("-y -i \"{0}\" -codec:a libmp3lame -b:a 128k \"{1}\"", source, target);

            info.RedirectStandardInput = false;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;


            using (var proc = new Process())
            {
                proc.StartInfo = info;
                proc.Start();
                Console.WriteLine(proc.StandardOutput.ReadToEnd());
            }
        }
    }
}

