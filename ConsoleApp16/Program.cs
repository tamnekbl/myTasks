using System.Xml.XPath;
object locker = new(); 
string dirName = "C://Users//Tamerlan//Desktop//dummy";

int count = 0;

List<Task> tasks = new List<Task>();

List<string> GetAllFiles(string dirName)
{
    if (Directory.Exists(dirName))
    {
        var nextList = new List<string>();
        var dirs = Directory.GetDirectories(dirName).ToList();
        foreach (string s in dirs)
        {
            nextList = nextList.Concat(GetAllFiles(s)).ToList();
        }
        var files = Directory.GetFiles(dirName).ToList();

        return files.Concat(nextList).ToList();
    }
    else return new List<string>();
}

void LinesCounter (object? obj)
{
    if (obj is string dirName)
    {
        string? line;
        TextReader reader = new StreamReader(dirName);
        
        while ((line = reader.ReadLine()) != null)
        {
        lock (locker)
        {
        count++; 
        }
            
        }
        reader.Close();
    }
}



var files = GetAllFiles(dirName);
foreach (var file in files)
{
    System.Console.WriteLine(file);
    tasks.Add(Task.Run(()=>LinesCounter(file)));
}

Task.WaitAll(tasks.ToArray());

System.Console.WriteLine(count);