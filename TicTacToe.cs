using System;

namespace TicTocGame
{
    class TicTacToe
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToeGame");
            char [] ticTacToeBoard =new TicTacToe().createBoard();
        }

        public char[] board = new char[10];
        public char [] createBoard()
        {
            for (int i = 0; i < board.Length; i++)
                board[i] = ' ';

            return board;
        }
    
    }

    }

    
    

