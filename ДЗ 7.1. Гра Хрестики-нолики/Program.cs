// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class TicTacToe
{
    static string[] board = new string[9];
    static string currentPlayer;

    static void Main()
    {
        // Ініціалізація гри
        InitBoard();
        currentPlayer = "X";

        // Гра
        while (true)
        {
            Console.Clear();
            DrawBoard();
            PlayerTurn();
            if (CheckWin())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine($"Гравець {currentPlayer} виграв!");
                break;
            }
            if (CheckDraw())
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("Нічия!");
                break;
            }
            SwitchPlayer();
        }
    }

    // Ініціалізація ігрового поля
    static void InitBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            board[i] = (i + 1).ToString();
        }
    }

    // Виведення ігрового поля
    static void DrawBoard()
    {
        Console.WriteLine("Ігрове поле:");
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    // Перемикач гравців
    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == "X") ? "O" : "X";
    }

    // Хід гравця
    static void PlayerTurn()
    {
        int choice;
        bool validMove = false;

        while (!validMove)
        {
            Console.WriteLine($"Гравець {currentPlayer}, виберіть клітинку (1-9): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != "X" && board[choice - 1] != "O")
            {
                board[choice - 1] = currentPlayer;
                validMove = true;
            }
            else
            {
                Console.WriteLine("Невірний хід! Спробуйте ще раз.");
            }
        }
    }

    // Перевірка на виграш
    static bool CheckWin()
    {
        // Перевірка горизонталей, вертикалей та діагоналей
        int[,] winPatterns = new int[,] {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 }
        };

        for (int i = 0; i < winPatterns.GetLength(0); i++)
        {
            if (board[winPatterns[i, 0]] == currentPlayer && board[winPatterns[i, 1]] == currentPlayer && board[winPatterns[i, 2]] == currentPlayer)
            {
                return true;
            }
        }

        return false;
    }

    // Перевірка на нічию
    static bool CheckDraw()
    {
        foreach (string cell in board)
        {
            if (cell != "X" && cell != "O")
            {
                return false;
            }
        }
        return true;
    }
}
