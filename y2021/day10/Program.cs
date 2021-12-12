var inputs = File.ReadAllLines("input.txt");
var matching = new Dictionary<char, char>(){['('] = ')', ['{'] = '}', ['['] = ']', ['<'] = '>'};
var corruptScores = new Dictionary<char, int>(){[')'] = 3, ['}'] = 57, [']'] = 1197, ['>'] = 25137, [' '] = 0};
var missingScores = new Dictionary<char, int>(){[')'] = 1, [']'] = 2, ['}'] = 3, ['>'] = 4};


char FindFirstCorrput(string input)
{
    var stack = new Stack<char>();
    foreach(char ch in input)
    {
        if("([{<".Contains(ch))
        {
            stack.Push(ch);
        }
        else
        {
            if(stack.Count == 0)
            {
                return ch;
            }
            else
            {
                var top = stack.Pop();
                if (ch != matching[top])
                    return ch;
            }
        }
    }
    return ' ';
}


int CalculateCorruptScore(string corrupts){
    var score = 0;
    foreach(char ch in corrupts)
        score += corruptScores[ch];
    return score;
}


string FindMissing(string input){
    var stack = new Stack<char>();
    foreach(char ch in input)
    {
        if("([{<".Contains(ch))
        {
            stack.Push(ch);
        }
        else
        {
            if(stack.Count == 0)
            {
                return ch.ToString();
            }
            else
            {
                var top = stack.Pop();
                if (ch != matching[top])
                    return "";
            }
        }
    }
    var missingCharacters = "";
    while(stack.Count > 0)
    {
        missingCharacters += matching[stack.Pop()];
    }
    return missingCharacters;
}


int CalculateMissingScore(string missing){
    var score = 0;
    foreach(char ch in missing)
        score = score * 5 + missingScores[ch];
    return score;
}

var corrupts = "";
foreach(var input in inputs)
    corrupts += FindFirstCorrput(input);

Console.WriteLine($"Part 1: {CalculateCorruptScore(corrupts)}");

var missingScoreList = new List<int>();
foreach(var input in inputs)
{
    var missing = FindMissing(input);
    if(missing != "")
        missingScoreList.Add(CalculateMissingScore(FindMissing(input)));
}
missingScoreList.Sort();
var missingScore = missingScoreList[missingScoreList.Count / 2];

Console.WriteLine($"Part 2: {missingScore}");