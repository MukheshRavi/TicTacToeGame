﻿using System;
using System.Collections.Generic;

namespace TicTocGame
{
    class TicTacToe
    {
       public  char computerSymbol;
        public char playerSymbol;
        public bool computerTurn;
        public static void Main(string[] args)
        {
            int entry;
            do
            {
                TicTacToe ticTacToe = new TicTacToe();
                Console.WriteLine("Welcome to TicTacToeGame");
                bool turn = ticTacToe.CoinToss();

                char[] ticTacToeBoard = ticTacToe.CreateBoard();
                ticTacToe.playerSymbol = ticTacToe.ChooseSymbol();
                ticTacToe.ShowBoard();
                ticTacToe.StartGame(turn);

                Console.WriteLine("enter choice 1:Play another Game  2:no play");
          entry   = Convert.ToInt32(Console.ReadLine());
            }

            while (entry == 1);
            }

        public char[]  ticTacToeBoard = new char[10];
       /// <summary>
       /// This method is to create board
       /// </summary>
       /// <returns></returns>
        public char [] CreateBoard()
        {
            for (int i = 0; i <  ticTacToeBoard.Length; i++)
                 ticTacToeBoard[i] = ' ';
            return  ticTacToeBoard;
        }
        /// <summary>
        /// This method is used to Choose players Symbol
        /// </summary>
        /// <returns></returns>
        public char ChooseSymbol()
        {

            Console.WriteLine("Enter your choice to choose Symbol 1:O 2:X");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    playerSymbol = 'O';
                    computerSymbol = 'X';
                    Console.WriteLine("you choose symbol " + playerSymbol);
                    return playerSymbol;

                case 2:
                    playerSymbol = 'X';
                    computerSymbol = 'O';
                    Console.WriteLine("you choose symbol " + playerSymbol);
                    return playerSymbol;

                default:
                    playerSymbol = ' ';
                    return playerSymbol;
                 }
        }
        /// <summary>
        /// This is to present board
        /// </summary>
            public void ShowBoard()
            {
                Console.WriteLine("   "+ ticTacToeBoard[1] + "|  " +  ticTacToeBoard[2] + "|  " +  ticTacToeBoard[3]);
                Console.WriteLine("------------------------" );
                Console.WriteLine("   "+ ticTacToeBoard[4] + "|  " +  ticTacToeBoard[5] + "|  " +  ticTacToeBoard[6]);
                Console.WriteLine("------------------------ " );
                Console.WriteLine("   "+ ticTacToeBoard[7] + "|  " +  ticTacToeBoard[8] + "|  " +  ticTacToeBoard[9]);
            }
        /// <summary>
        /// This is make the move by player
        /// </summary>
        /// <param name="playerSymbol"></param>
        public void MakeMove()
        {

            Console.WriteLine("Enter your choice to mark any location i.e between 1 to 9");
            int choice = Convert.ToInt32(Console.ReadLine());
            if ( ticTacToeBoard[choice] ==' ')
            {
                 ticTacToeBoard[choice] = playerSymbol;
                Console.WriteLine("");
                ShowBoard();
            
            }
            else
            {
                Console.WriteLine("This position is already filled");
                MakeMove();
            }
        }
        public bool CoinToss()
        {
            bool playerturn = false;
            TicTacToe t = new TicTacToe();
            Console.WriteLine("Enter your choice for coin toss 0:Heads 1:tails");
            int choice = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            if (choice == random.Next(2))
            {
                Console.WriteLine("player won the toss and starts game");
                playerturn = true;
              
                return playerturn;
            }
            else
            { Console.WriteLine(" computer starts game");
                return playerturn;
                    } 
        }

        public void ComputerMove(char[] board)
        {
            int choice = 0;
            Random rand = new Random();

            computerTurn = true;
            //for getting Computer move to win
            for (int i = 1; i < 10; i++)
            {
                if (board[i] == ' ')
                {
                    board[i] = computerSymbol;
                    if (CheckWinner(board, computerSymbol))
                    {
                        board[i] = ' ';
                        choice = i;
                        break;
                    }
                    else
                    {
                        board[i] = ' ';

                        //for getting computer move to not lose to player

                        for (int j = 1; j < 10; j++)
                        {
                            if (board[j] == ' ')
                            {
                                board[j] = playerSymbol;
                                if (CheckWinner(board, playerSymbol))
                                {
                                    board[j] = ' ';
                                    choice = j;
                                    break;
                                }
                                else
                                {
                                    board[j] = ' ';
                                    //for taking corner moves
                                    if (board[1] == ' ' || board[3] == ' ' || board[7] == ' ' || board[9] == ' ')
                                    {
                                        List<int> list = new List<int> { 1, 3, 7, 9 };
                                        int index = rand.Next(list.Count);
                                        choice = list[index];
                                    }
                                    //for taking Center
                                    else
                                    {
                                        if (board[5] == ' ')
                                            choice = 5;
                                        //for choosing any random value
                                        else
                                            choice = rand.Next(10);

                                    }
                                }
                            }

                        }
                    }
                }
            } 
        



           

            if (board[choice] == ' ')
                {
                    board[choice] = computerSymbol;
                Console.WriteLine("");
                    ShowBoard();
                    
                }
                else
                {
                    ComputerMove(ticTacToeBoard);

                }
               }
     
        public void StartGame(bool turn)
        {
            if (ticTacToeBoard[1] != ' ' && ticTacToeBoard[2] != ' ' && ticTacToeBoard[3] != ' ' && ticTacToeBoard[4] != ' ' &&
              ticTacToeBoard[5] != ' ' && ticTacToeBoard[6] != ' ' && ticTacToeBoard[7] != ' ' && ticTacToeBoard[8] == ' '
              && ticTacToeBoard[9] != ' ')
            {
                Console.WriteLine("Match Tied");
                Environment.Exit(0);
            }

                if (turn)
            {
                bool isWinner = CheckWinner(ticTacToeBoard,computerSymbol);
                if (!isWinner)
                {
                    MakeMove();
                    turn = false;
                    StartGame(turn);
                }

                else
                    DeclareWinner(turn);
                    

                
            }
            else
            {
                bool isWinner = CheckWinner(ticTacToeBoard,playerSymbol);
                if (!isWinner)
                {
                    
                   ComputerMove(ticTacToeBoard);
                    turn = true;
                    StartGame(turn);
                }
                else
                    DeclareWinner(turn);


            }
        }
          
        
        public bool CheckWinner( char[] board,char symbol)
            {
                bool isWinner = false;
            //for Horizontal Winning
                for (int i = 1; i < 8;)
                {
                    if (board[i].Equals(symbol) && board[i + 1].Equals(symbol) && board[i + 2].Equals(symbol))
                    {
                        isWinner = true;
                    }
                    i += 3;
                }
                //for Vertical Winning
                for (int i = 1; i < 4; i++)
                {
                    if (board[i].Equals(symbol) && board[i + 3].Equals(symbol) && board[i + 6].Equals(symbol))
                    {
                        isWinner = true;
                    }
                }
                //for diagonal Winning
                if (board[1].Equals(symbol) && board[5].Equals(symbol) && board[9].Equals(symbol))
                {
                    isWinner = true;
                }
                if (board[3].Equals(symbol) && board[5].Equals(symbol) && board[7].Equals(symbol))
                {
                    isWinner = true;
                }

                return isWinner;
            }
          
        public void DeclareWinner(bool turn)
        {if (turn)
                Console.WriteLine("Computer Won the match");
            else
                Console.WriteLine("player won the match");
           
        }

        

        }
    }



    
    

