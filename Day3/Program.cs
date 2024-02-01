using System.Text.RegularExpressions;

var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
var allLines = File.ReadAllLines(fileName);
var numberRegex = new Regex(@"(\d)+");
var symbolRegex = new Regex(@"[^\.\d\n]");

var symbols = new List<Symbol>();
var numbers = new List<Number>();
var lineNum = 0;
foreach (var line in allLines)
{
    foreach (Match nm in numberRegex.Matches(line))
    {
        numbers.Add(new Number(
            Value: int.Parse(nm.Value),
            Position: new Position(nm.Index, nm.Index + nm.Length - 1, lineNum)));
    }

    foreach (Match sm in symbolRegex.Matches(line))
    {
        symbols.Add(new Symbol(
            Value: sm.Value,
            Position: new Position(sm.Index, sm.Index, lineNum)));
    }

    lineNum++;
}

var partSum = numbers
            .Where(n => symbols.Any(s => s.Position.IsAdj(n)))
            .Sum(n => n.Value);

var ratio = symbols
    .Where(s => s.Value is "*")
    .Sum(g =>
    {
        var adjacentNumbers = numbers
            .Where(n => g.Position.IsAdj(n))
            .ToList();
        return adjacentNumbers.Count == 2
            ? adjacentNumbers.Aggregate(1, (acc, n) => acc * n.Value)
            : 0;
    });

Console.WriteLine($"Part 1 answer: {partSum}");
Console.WriteLine($"Part 2 answer: {ratio}");

record Symbol(string Value, Position Position);

record Number(int Value, Position Position);

class Position
{
    public int Start { get; private set; }
    public int End { get; private set; }
    public int Row { get; private set; }

    public Position(int start, int end, int row)
    {
        (Start, End, Row) = (start, end, row);
    }

    public bool IsAdj(Number number)
    {
        if (Row < number.Position.Row - 1 || Row > number.Position.Row + 1) return false;
        return Start >= number.Position.Start - 1 && Start <= number.Position.End + 1;
    }
}