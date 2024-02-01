using System.Diagnostics.Metrics;
using System.Text;

var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
Console.WriteLine(fileName);

List<char[]> lines = new List<char[]>();
var allLines = File.ReadAllLines(fileName);
foreach (string line in allLines)
{
    lines.Add(line.ToCharArray());
}

Console.WriteLine(lines.Count());

int counter = 0;

foreach (var line in lines)
{
    for (int i = 0; i < line.Length; i++)
    {
        
    }
}




bool isValid(List<char[]> lines, int i, int j)
{
    if (!lines[i][j].Equals("."))
    {
        return true;
    }
    return false;
}