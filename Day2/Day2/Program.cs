var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
var counter = 0;

//12 red, 13 green, 14 blue

var lines = File.ReadAllLines(fileName);
foreach (var line in lines)
{
    int pFrom = line.IndexOf("Game ") + "Game ".Length;
    int pTo = line.IndexOf(":");
    int gameNo = Int32.Parse(line.Substring(pFrom, pTo-pFrom));
    bool isImpossible = false;

    String rest = line.Substring(pTo + 1);
    var infoSplits = rest.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);

    foreach (String info in infoSplits) 
    {
        //Console.WriteLine(info);
        String[] draws = info.Split(",");

        int redNo = 0;
        int greenNo = 0;
        int blueNo = 0;
        foreach (String draw in draws)
        {
            if (draw.Contains("red"))
            {
                redNo = Int32.Parse(draw.Replace("red", "").Trim());
                if (redNo > 12) { isImpossible = true; break; }
            } else if (draw.Contains("blue"))
            {
                blueNo = Int32.Parse(draw.Replace("blue", "").Trim());
                if (blueNo > 14) { isImpossible = true; break; }
            }
            else if (draw.Contains("green"))
            {
                greenNo = Int32.Parse(draw.Replace("green", "").Trim());
                if (greenNo > 13) { isImpossible = true; break; }
            }
        }

        if (redNo + greenNo > 25 || redNo + blueNo > 26 || blueNo + greenNo > 27 || redNo + greenNo + blueNo > 39)
        {
            isImpossible = true;
        }

        if (isImpossible)
        {
            break;
        }
    }

    if (!isImpossible)
    {
        Console.WriteLine(gameNo);
        counter += gameNo;
    }
}

Console.WriteLine(counter);
Console.WriteLine("PART 2");

// PART 2

counter = 0;

//12 red, 13 green, 14 blue


lines = File.ReadAllLines(fileName);

foreach (var line in lines)
{
    int pFrom = line.IndexOf("Game ") + "Game ".Length;
    int pTo = line.IndexOf(":");
    int gameNo = Int32.Parse(line.Substring(pFrom, pTo - pFrom));

    String rest = line.Substring(pTo + 1);
    var infoSplits = rest.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

    int redNo = 0;
    int greenNo = 0;
    int blueNo = 0;

    foreach (String info in infoSplits)
    {
        //Console.WriteLine(info);
        String[] draws = info.Split(",");

        foreach (String draw in draws)
        {
            if (draw.Contains("red"))
            {
                int no = Int32.Parse(draw.Replace("red", "").Trim());
                if (no > redNo) { redNo = no; }
            }
            else if (draw.Contains("blue"))
            {
                int no = Int32.Parse(draw.Replace("blue", "").Trim());
                if (no > blueNo) { blueNo = no; }
            }
            else if (draw.Contains("green"))
            {
                int no = Int32.Parse(draw.Replace("green", "").Trim());
                if (no > greenNo) { greenNo = no; }
            }
        }
    }

    Console.WriteLine(redNo + " " +  greenNo + " " + blueNo);
    counter += (redNo > 0 ? redNo : 1) * (greenNo > 0 ? greenNo : 1) * (blueNo > 0 ? blueNo : 1);
}

Console.WriteLine(counter);
