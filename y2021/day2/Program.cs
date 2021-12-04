string[] Instructions() => File.ReadAllLines("c:\\AOC\\02.txt").ToArray();

int Move(string[] instructions){
    int position = 0;
    int depth = 0;

    foreach(var instruction in instructions){
        var parts = instruction.Split(' ');
        var op = parts[0];
        var value = int.Parse(parts[1]);

        if(op == "forward"){
            position += value;
        }
        else if(op == "up"){
            depth -= value;
        }
        else if(op == "down"){
            depth += value;
        }
    }

    return position * depth;
}

int Move2(string[] instructions){
    int position = 0;
    int depth = 0;
    int aim = 0;

    foreach(var instruction in instructions){
        var parts = instruction.Split(' ');
        var op = parts[0];
        var value = int.Parse(parts[1]);

        if(op == "forward"){
            position += value;
            depth += aim * value;
        }
        else if(op == "up"){
            aim -= value;
        }
        else if(op == "down"){
            aim += value;
        }
    }

    return position * depth;
}

Console.WriteLine($"Part 1: {Move(Instructions())}");
Console.WriteLine($"Part 2: {Move2(Instructions())}");
