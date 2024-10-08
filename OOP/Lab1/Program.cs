using System;
using System.Collections.Generic;

class GameAccount {
    public string UserName { get; set; }
    public int CurrentRating { get; set; } 
    public int GamesCount { get; set; }

    private List<Game> gameHistory;

    public GameAccount(string userName, int currentRating) { 
        UserName = userName;
        CurrentRating = currentRating >= 1 ? currentRating : 1;
        GamesCount = 0;
        gameHistory = new List<Game>();
    }

    public void WinGame(string opponentName, int rating) {
        if (rating < 0) throw new ArgumentException("Rating cannot be negative.");

        CurrentRating += rating;
        GamesCount++;
        var game = new Game(opponentName, true, rating);
        gameHistory.Add(game);
    }

    public void LoseGame(string opponentName, int rating) {
        if (rating < 0) throw new ArgumentException("Rating cannot be negative.");

        CurrentRating = Math.Max(CurrentRating - rating, 1);
        GamesCount++;
        var game = new Game(opponentName, false, rating);
        gameHistory.Add(game);

    }

    public void GetStats()  {
        Console.WriteLine($"Game stats for {UserName}:");
        Console.WriteLine("Game number |                Game id               | Opponent | Result | Rating ");
        Console.WriteLine("----------------------------------------------------------------------------------");
        for (int i = 0; i < gameHistory.Count; i++) { 
            var game = gameHistory[i];
            Console.WriteLine($"{i + 1}           | {game.GameId} |  {game.OpponentName}  |   {(game.IsWin ? "Win " : "Loss")} | {game.Rating}");
        }
        Console.WriteLine();
    }
}

class Game {
    public string OpponentName { get; private set; }
    public bool IsWin { get; private set; }
    public int Rating { get; private set; }
    public Guid GameId { get; private set; }

    public Game(string opponentName, bool isWin, int rating) {
        OpponentName = opponentName;
        IsWin = isWin;
        Rating = rating;
        GameId = Guid.NewGuid(); 
    }

}

class Program
{
    static void Main(string[] args)
    {
        GameAccount player1 = new GameAccount("Gamer1", 1500);
        GameAccount player2 = new GameAccount("Gamer2", 1600);

        // games simulation
        player1.WinGame(player2.UserName, 50);
        player2.LoseGame(player1.UserName, 50);

        player1.LoseGame(player2.UserName, 100);
        player2.WinGame(player1.UserName, 100);

        // print stats
        player1.GetStats();
        player2.GetStats();
    }
}