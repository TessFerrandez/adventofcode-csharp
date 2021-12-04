string[] Lines() => File.ReadAllLines("c:\\AOC\\04.txt").ToArray();

Dictionary<int, int> CallOrder(string calls){
    var dict = new Dictionary<int, int>();
    int[] numbers = calls.Split(',').Select(int.Parse).ToArray();
    for(int i = 0; i < numbers.Length; i++){
        dict.Add(numbers[i], i);
    }
    return dict;
}

List<List<List<int>>> Boards(string[] Lines){
    var boards = new List<List<List<int>>>();
    int row = 0;
    List<List<int>> board = null;

    foreach(string line in Lines){
        if(row == 0){
            row++;
            continue;
        }
        if(line == ""){
            if(board != null){
                boards.Add(board);
            }
            board = new List<List<int>>();
        }
        else{
            board.Add(line.Split(' ').Where(x => x != "").Select(int.Parse).ToList());
        }
    }
    boards.Add(board);
    return boards;
}

int[] WinningMoves(List<List<List<int>>> boards, Dictionary<int, int> callOrder){
    var winningMoves = new int[boards.Count];

    int boardIndex = 0;
    foreach(var board in boards){
        var leastMoves = callOrder.Count;

        // rows
        foreach(var row in board){
            var rowWinningMove = row.Select(x => callOrder[x]).Max();
            leastMoves = Math.Min(leastMoves, rowWinningMove);
        }

        // columns
        for(int col = 0; col < 5; col++){
            var colWinningMove = board.Select(row => row[col]).ToList().Select(x => callOrder[x]).Max();
            leastMoves = Math.Min(leastMoves, colWinningMove);
        }
        winningMoves[boardIndex] = leastMoves;
        boardIndex++;
    }
    return winningMoves;
}

int CalculateBoard(List<List<int>> board, Dictionary<int, int> callOrder, int move){
    int sumOfNotCalled = 0;
    foreach(var row in board){
        sumOfNotCalled += row.Where(x => callOrder[x] > move).Sum();
    }

    int lastMove = callOrder.Where(x => x.Value == move).Select(x => x.Key).First();

    return sumOfNotCalled * lastMove;
}

var callOrder = CallOrder(Lines()[0]);
var boards = Boards(Lines());
var winningMoves = WinningMoves(boards, callOrder);

int winningBoardNumber = winningMoves.ToList().IndexOf(winningMoves.Min());
List<List<int>> winningBoard = boards[winningBoardNumber];
Console.WriteLine(CalculateBoard(winningBoard, callOrder, winningMoves[winningBoardNumber]));

int loosingBoardNumber = winningMoves.ToList().IndexOf(winningMoves.Max());
List<List<int>> loosingBoard = boards[loosingBoardNumber];
Console.WriteLine(CalculateBoard(loosingBoard, callOrder, winningMoves[loosingBoardNumber]));
