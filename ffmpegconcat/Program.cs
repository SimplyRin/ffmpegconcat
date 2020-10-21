using System;
using System.Diagnostics;
using System.IO;

/**
 * 5分クオリティー
 */
namespace ffmpegconcat {

    public class Program {

        public static void Main(String[] args) {
            String value = "";

            foreach (String file in Directory.GetFiles(".", "*")) {
                if (!file.EndsWith(".ts")) {
                    continue;
                }
                String name;
                if (file.StartsWith(".\\")) {
                    name = file.Substring(2);
                } else {
                    name = file;
                }
                Console.WriteLine("file " + name);
                value += "file " + name + "\n";
            }

            File.WriteAllText("files.txt", value);

            String command = "ffmpeg -f concat -safe 0 -i files.txt -c copy video.mp4";
            File.WriteAllText("run.bat", command);

            Console.WriteLine("\nExecute: " + command);

            Process process = new Process();
            process.StartInfo.FileName = "run.bat";
            process.Start();
            process.WaitForExit();
        }
    }
}
