string[] Numbers() => File.ReadAllLines("c:\\AOC\\03.txt").ToArray();

int GammaRate(string[] numbers){
    string result = "";

    for (int i = 0; i < numbers[0].Length; i++){
        int zeros = 0;
        int ones = 0;
        foreach(var number in numbers){
            if (number[i] == '0'){
                zeros++;
            } else {
                ones++;
            }
        }
        if(zeros > ones){
            result += '0';
        } else {
            result += '1';
        }
    }
    return Convert.ToInt32(result, 2);
}

int EpsilonRate(string[] numbers){
    string result = "";

    for (int i = 0; i < numbers[0].Length; i++){
        int zeros = 0;
        int ones = 0;
        foreach(var number in numbers){
            if (number[i] == '0'){
                zeros++;
            } else {
                ones++;
            }
        }
        if(zeros > ones){
            result += '1';
        } else {
            result += '0';
        }
    }
    return Convert.ToInt32(result, 2);
}

int OxygenRate(string[] numbers){
    int numLenght = numbers[0].Length;

    for (int i = 0; i < numLenght; i++){
        int zeros = 0;
        int ones = 0;
        foreach(var number in numbers){
            if (number[i] == '0'){
                zeros++;
            } else {
                ones++;
            }
        }
        char bit = ones >= zeros? '1' : '0';
        numbers = numbers.Where(x => x[i] == bit).ToArray();
        if (numbers.Length == 1){
            return Convert.ToInt32(numbers[0], 2);
        }
    }
    return 0;
}

int CO2Rate(string[] numbers){
    int numLenght = numbers[0].Length;

    for (int i = 0; i < numLenght; i++){
        int zeros = 0;
        int ones = 0;
        foreach(var number in numbers){
            if (number[i] == '0'){
                zeros++;
            } else {
                ones++;
            }
        }
        char bit = ones >= zeros ? '0' : '1';
        numbers = numbers.Where(x => x[i] == bit).ToArray();
        if (numbers.Length == 1){
            return Convert.ToInt32(numbers[0], 2);
        }
    }
    return 0;
}

Console.WriteLine(GammaRate(Numbers()) * EpsilonRate(Numbers()));
Console.WriteLine(OxygenRate(Numbers()) * CO2Rate(Numbers()));
