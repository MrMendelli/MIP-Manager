using System;
using System.IO;

internal class MIPManager
{
    static void Main()
    {
        // Set window title as executable name dynamically
        Console.Title = AppDomain.CurrentDomain.FriendlyName;
        string workingDir = Directory.GetCurrentDirectory();
        // @""; String literal = Read implicitly (delimeter escaping is not required)
        const string targetPath = @".\MIP Maps\";
        Directory.CreateDirectory(targetPath);

        if (Directory.Exists(targetPath)) {
            int mipCount = 0;
            bool mipExists = false;
            string[] fileArray = Directory.GetFiles(workingDir);
            foreach (string filePath in fileArray) {
                string fileName = Path.GetFileName(filePath);

                if (fileName.Contains("_mip")) {
                    mipCount++;
                    mipExists = true;
                    string fileDestination = Path.Combine(targetPath, fileName);
                    File.Move(filePath, fileDestination, true);
                    // $ = Smart string "{<variable>}"
                    Console.Write($"Moved mip map: ");
                    string[] splitName = fileName.Split("_mip");
                    Console.Write(splitName[0]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("_mip");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(splitName[1]);
                    Console.WriteLine();
                }
            }

            // !<var> = == false
            if (!mipExists) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No mip maps found.\nPress any key to exit...");
                Console.ReadKey();
            }
            else {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nFinished moving {mipCount} mip maps.\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
