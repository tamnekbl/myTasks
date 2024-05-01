using System.Xml.XPath;
using System.Diagnostics;
object locker = new(); 
string dirName = @"C:\Logs";

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
            Interlocked.Increment(ref count);
            
        }
        reader.Close();
    }
}

Stopwatch st = new Stopwatch();
st.Start();

var files = GetAllFiles(dirName);
foreach (var file in files)
{
    //System.Console.WriteLine(file);
    tasks.Add(Task.Run(()=>LinesCounter(file)));
}

        
Task.WaitAll(tasks.ToArray());
st.Stop();
Console.WriteLine("Время выполнения: {0}", st.Elapsed.TotalSeconds);
Console.WriteLine(count);