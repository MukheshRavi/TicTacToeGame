using System;

namespace TicTocGame
{
    class TicTacToe
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = new TicTacToe();
            Console.WriteLine("Welcome to TicTacToeGame");
            char [] ticTacToeBoard =ticTacToe.createBoard();
            ticTacToe.chooseSymbol();

        }

        public char[] board = new char[10];
        public char [] createBoard()
        {
            for (int i = 0; i < board.Length; i++)
                board[i] = ' ';

            return board;
        }
        public void chooseSymbol()
        {

            Console.WriteLine("Enter your choice to choose Symbol 1:O 2:X");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    char playerSymbol = 'O';
                    Console.WriteLine("you choose symbol" + playerSymbol);
                    break;
                case 2:
                    playerSymbol = 'X';
                    Console.WriteLine("you choose symbol" + playerSymbol);
                    break;
            }

        }

    }

}

    
    

