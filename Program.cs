using System.IO;
using System.Collections.Generic;

Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "stores", "201", "NewDir"));


var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);


var salesFiles = FindFiles(storesDirectory);
File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);
  
File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");


foreach (var file in salesFiles)
{
    Console.WriteLine(file);
}

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
        
    }

    return salesFiles;
}

