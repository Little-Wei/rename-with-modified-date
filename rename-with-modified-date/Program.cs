using System;
using System.IO;

//string folderPath = Directory.GetCurrentDirectory();
string folderPath = @"Your Folder Path"; // Change this to your target folder path
if (!Directory.Exists(folderPath))
{
    Console.WriteLine("指定的資料夾不存在。");
    return;
}

var files = Directory.GetFiles(folderPath);

foreach (var file in files)
{
    var info = new FileInfo(file);
    var lastWrite = info.LastWriteTime;
    string newFileName = lastWrite.ToString("yyyyMMdd_HHmmss") + info.Extension;
    //Console.WriteLine($"{info.Name} -> {newFileName}");
    string newPath = Path.Combine(folderPath, newFileName);
    if (!File.Exists(newPath))
    {
        File.Move(file, newPath);
        Console.WriteLine($"{info.Name} -> {newFileName}");
    }
    else
    {
        Console.WriteLine($"{newFileName} 已存在，略過 {info.Name}");
    }
}
