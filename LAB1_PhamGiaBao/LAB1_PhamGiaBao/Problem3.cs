using System;

public class WordSearch
{
    public bool Exist(char[][] board, string word)
    {
        int rows = board.Length;
        int cols = board[0].Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (Backtrack(board, word, i, j, 0))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool Backtrack(char[][] board, string word, int row, int col, int index)
    {
        if (index == word.Length)
        {
            return true; 
        }

        if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length || board[row][col] != word[index])
        {
            return false;
        }

        char temp = board[row][col];
        board[row][col] = '#';

        bool found = Backtrack(board, word, row - 1, col, index + 1) ||
                     Backtrack(board, word, row + 1, col, index + 1) || 
                     Backtrack(board, word, row, col - 1, index + 1) || 
                     Backtrack(board, word, row, col + 1, index + 1);   

        board[row][col] = temp;

        return found;
    }

    public static void Main(string[] args)
    {
        WordSearch ws = new WordSearch();

        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        char[][] board = new char[rows][];
        Console.WriteLine("Enter the board row by row (characters separated by spaces):");
        for (int i = 0; i < rows; i++)
        {
            board[i] = Console.ReadLine().Split(' ').Select(c => c[0]).ToArray(); 
        }

        Console.Write("Enter the word to search: ");
        string word = Console.ReadLine();

        
        bool result = ws.Exist(board, word);
        Console.WriteLine(result ? "Word found!" : "Word not found.");
    }
}
