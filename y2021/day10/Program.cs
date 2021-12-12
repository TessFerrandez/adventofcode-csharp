var inputs = File.ReadAllLines("input.txt");
var matching = new Dictionary<char, char>(){['('] = ')', ['{'] = '}', ['['] = ']', ['<'] = '>'};
var corruptScores = new Dictionary<char, int>(){[')'] = 3, ['}'] = 57, [']'] = 1197, ['>'] = 25137, [' '] = 0};
var missingScores = new Dictionary<char, int>(){[')'] = 1, [']'] = 2, ['}'] = 3, ['>'] = 4};


char FindFirstCorrput(string input, Dictionary<char, char> matching)
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


int CalculateCorruptScore(string corrupts, Dictionary<char, int> corruptScores){
    var score = 0;
    foreach(char ch in corrupts)
        score += corruptScores[ch];
    return score;
}


string FindMissing(string input, Dictionary<char, char> matching){
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


int CalculateMissingScore(string missing, Dictionary<char, int> missingScores){
    var score = 0;
    foreach(char ch in missing)
        score = score * 5 + missingScores[ch];
    return score;
}


int GetCorruptScoreForAllStrings(string[] inputs, Dictionary<char, char> matching, Dictionary<char, int> corruptScores){
    var corrupts = "";
    foreach(var input in inputs)
        corrupts += FindFirstCorrput(input, matching);
    return CalculateCorruptScore(corrupts, corruptScores);
}


int GetMissingScoreForAllStrings(String[] inputs, Dictionary<char, char> matching, Dictionary<char, int> missingScores){
    var missingScoreList = new List<int>();
    foreach(var input in inputs)
    {
        var missing = FindMissing(input, matching);
        if(missing != "")
            missingScoreList.Add(CalculateMissingScore(missing, missingScores));
    }
    missingScoreList.Sort();
    var missingScore = missingScoreList[missingScoreList.Count / 2];
    return missingScore;
}


Console.WriteLine($"Part 1: {GetCorruptScoreForAllStrings(inputs, matching, corruptScores)}");
Console.WriteLine($"Part 2: {GetMissingScoreForAllStrings(inputs, matching, missingScores)}");