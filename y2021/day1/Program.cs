// extracting depths
int[] Depths() => File.ReadAllLines("c:\\AOC\\01.txt").Select(int.Parse).ToArray();

// get list of windowed elements
IEnumerable<int[]> Window(int[] depths, int window_size) => Enumerable.Range(0, depths.Length - window_size + 1).Select(i => depths[i..(i + window_size)]);

// extracting depths (3 by 3)
int[] ThreeDepths(int[] depths) => (from ds in Window(depths, 3) select ds.Sum()).ToArray();

// calculate increasing depths
int CountIncreasingDepths(int[] depths) => Window(depths, 2).Count(ds => ds[0] < ds[1]);

Console.WriteLine($"Part 1: {CountIncreasingDepths(Depths())}");
Console.WriteLine($"Part 1: {CountIncreasingDepths(ThreeDepths(Depths()))}");
