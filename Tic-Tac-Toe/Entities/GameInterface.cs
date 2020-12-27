using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.Entities
{
    class GameInterface
    {
        public Game CurrentGame { get; private set; }

        public GameInterface(Game currentGame)
        {
            CurrentGame = currentGame;
        }

        public void UpdateScreen()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                //Write the reference grid line number in most left side
                Console.Write((3 - i).ToString() + " ");
                //Print the TTT grid as in current game status
                for (int j = 0; j < 3; j++)
                {
                    string markInPosition = CurrentGame.GameGrid.Status[i,j];
                    if (markInPosition == null) markInPosition = " ";
                    if (j < 2)
                    {
                        Console.Write(" " + markInPosition + " |");
                    }
                    else
                    {
                        Console.Write(" " + markInPosition);
                    }
                }
                Console.WriteLine();
                if (i < 2)
                {
                    Console.WriteLine("  --- --- ---");
                }
                else
                {
                    Console.WriteLine("   a   b   c");
                }
            }
            Console.WriteLine();
        }

        public Position GetPlayerMove()
        {
            Console.Write("Player " + CurrentGame.CurrentTurnMark + " move: (ex: 1a): ");
            string smove = Console.ReadLine();
            if (smove.Length == 2)
            {
                Position move = new Position(smove[1], int.Parse(smove[0].ToString()));
                return move;
            }
            else
            {
                throw new ApplicationException("Two characters expected as playing position! Try again!");
            }
        }
    }
}
