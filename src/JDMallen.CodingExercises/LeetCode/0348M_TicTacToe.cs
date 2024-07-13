using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JDMallen.CodingExercises.LeetCode;

public class TicTacToe
{
    private readonly char[][] _board; // for debugging
    private readonly int _boardSize;
    private readonly int[] _cols;
    private readonly int[] _rows;
    private int _diag;
    private int _antiDiag;

    public TicTacToe(int n)
    {
        _board = new char[n][];
        for (var i = 0; i < _board.Length; i++)
        {
            _board[i] = new char[n];
        }

        _boardSize = n;
        _cols = new int[n];
        _rows = new int[n];
        _diag = 0;
        _antiDiag = 0;
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        var board = new StringBuilder();
        foreach (char[] row in _board)
        {
            board.Append('|');

            foreach (char val in row.Select(c => c != '\0' ? c : ' '))
            {
                board.Append($"{val}|");
            }

            board.AppendLine();
        }

        return board.ToString();
    }

    public int Move(int row, int col, int player)
    {
        // 0,0 is top left; n,n is bottom right
        // move is guaranteed to be valid, so no need to check for existing play

        // just for debugging:
        char piece = player == 1 ? 'X' : 'O';
        _board[row][col] = piece;
        Debug.WriteLine(this);

        int playerValue = player == 1 ? 1 : -1;

        if (Math.Abs(_rows[row] += playerValue) == _boardSize
            || Math.Abs(_cols[col] += playerValue) == _boardSize
            || row == col && Math.Abs(_diag += playerValue) == _boardSize
            || row + col == _boardSize - 1 && Math.Abs(_antiDiag += playerValue) == _boardSize)
        {
            return player;
        }

        return 0;
    }
}
