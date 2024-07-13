using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JDMallen.CodingExercises.LeetCode;

public class TicTacToe_BruteForce
{
    private readonly char[][] _board;
    private readonly int _boardSize;

    public TicTacToe_BruteForce(int n)
    {
        _board = new char[n][];
        for (var i = 0; i < _board.Length; i++)
        {
            _board[i] = new char[n];
        }

        _boardSize = n;
    }

    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        var board = new StringBuilder();
        for (var i = 0; i < _board.Length; i++)
        {
            board.Append('|');

            for (int j = 0; j < _board[i].Length; j++)
            {
                var val = _board[i][j] != '\0' ? _board[i][j] : ' ';
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
        char piece = player == 1 ? 'X' : 'O';
        _board[row][col] = piece;

        Debug.WriteLine(this);

        // there are x*2+2 possible win states for each player-- check them all

        // each row
        for (var i = 0; i < _board.Length; i++)
        {
            if (_board[i].All(c => c == 'X'))
            {
                return 1;
            }

            if (_board[i].All(c => c == 'O'))
            {
                return 2;
            }
        }

        // each column
        for (var j = 0; j < _board.Length; j++)
        {
            var column = new char[_boardSize];

            for (var i = 0; i < _board[j].Length; i++)
            {
                column[i] = _board[i][j];
            }

            if (column.All(c => c == 'X'))
            {
                return 1;
            }

            if (column.All(c => c == 'O'))
            {
                return 2;
            }
        }

        // each diagonal

        var topLeftBottomRight = new char[_boardSize];

        for (var i = 0; i < _board.Length; i++)
        {
            for (var j = 0; j < _board[i].Length; j++)
            {
                if (i == j)
                {
                    var next = _board[i][j];
                    topLeftBottomRight[i] = next;
                }
            }
        }

        if (topLeftBottomRight.All(c => c == 'X'))
        {
            return 1;
        }

        if (topLeftBottomRight.All(c => c == 'O'))
        {
            return 2;
        }

        var topRightBottomLeft = new char[_boardSize];

        for (var i = 0; i < _board.Length; i++)
        {
            for (var j = _board[i].Length - 1; j >= 0; j--)
            {
                var isCenterPiece = i == _boardSize / 2 && i < _boardSize - 1 && i == j;
                var isOnDiagonal = Math.Abs(j + i) == _boardSize - 1;
                if (isCenterPiece || isOnDiagonal)
                {
                    topRightBottomLeft[i] = _board[i][j];
                }
            }
        }

        if (topRightBottomLeft.All(c => c == 'X'))
        {
            return 1;
        }

        if (topRightBottomLeft.All(c => c == 'O'))
        {
            return 2;
        }

        return 0;
    }
}
