string[] Numbers() => File.ReadAllLines("c:\\AOC\\03.txt").ToArray();

char MostCommonAtI(string[] numbers, int i)
{
    int ones = 0;
    foreach(var number in numbers){
        if (number[i] == '1')
            ones++;
    }
    return ones > numbers.Length / 2 ? '1' : '0';
}

int GammaTimesEpsilon(string[] numbers)
{
    string gamma = "";
    string epsilon = "";

    for (int i = 0; i < numbers[0].Length; i++){
        gamma += MostCommonAtI(numbers, i);
        epsilon += MostCommonAtI(numbers, i) == "1" ? "0" : "1";
    }
    return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
}

int OxygenRate(string[] numbers){
    int numLenght = numbers[0].Length;

    for (int i = 0; i < numLenght; i++){
        numbers = numbers.Where(x => x[i] == MostCommonAtI(numbers, i)).ToArray();
        if (numbers.Length == 1){
            return Convert.ToInt32(numbers[0], 2);
        }
    }
    return 0;
}

int CO2Rate(string[] numbers){
    int numLenght = numbers[0].Length;

    for (int i = 0; i < numLenght; i++){
        char bit = MostCommonAtI(numbers, i) == '1' ? '0' : '1';
        numbers = numbers.Where(x => x[i] == bit).ToArray();
        if (numbers.Length == 1){
            return Convert.ToInt32(numbers[0], 2);
        }
    }
    return 0;
}

Console.WriteLine(GammaTimesEpsilon(Numbers()));
Console.WriteLine(OxygenRate(Numbers()) * CO2Rate(Numbers()));
