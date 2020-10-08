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
            char playerSymbol=ticTacToe.chooseSymbol();
            ticTacToe.showBoard();

        }

        public char[] board = new char[10];
       /// <summary>
       /// This method is to create board
       /// </summary>
       /// <returns></returns>
        public char [] createBoard()
        {
            for (int i = 0; i < board.Length; i++)
                board[i] = ' ';

            return board;
        }
        /// <summary>
        /// This method is used to Choose players Symbol
        /// </summary>
        /// <returns></returns>
        public char chooseSymbol()
        {

            Console.WriteLine("Enter your choice to choose Symbol 1:O 2:X");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    char playerSymbol = 'O';
                    Console.WriteLine("you choose symbol " + playerSymbol);
                    return playerSymbol;

                case 2:
                    playerSymbol = 'X';
                    Console.WriteLine("you choose symbol " + playerSymbol);
                    return playerSymbol;
                default:
                    Console.WriteLine("choice is wrong");
                    playerSymbol = ' ';
                    return playerSymbol;

            }
        }

            public void showBoard()
            {
                Console.WriteLine(board[1] + "|" + board[2] + "|" + board[3]);
                Console.WriteLine("--" + " " + "--" + " " + "--");
                Console.WriteLine(board[4] + "|" + board[5] + "|" + board[6]);
                Console.WriteLine("--" + " " + "--" + " " + "--");
                Console.WriteLine(board[7] + "|" + board[8] + "|" + board[9]);
            }


        

    }

}

    
    

