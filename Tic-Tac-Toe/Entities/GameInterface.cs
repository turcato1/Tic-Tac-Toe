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
            for (int y = 0; y < 3; y++)
            {
                //Write the reference grid line number in most left side
                Console.Write((3 - y).ToString() + " ");
                //Print the TTT grid as in current game status
                for (int x = 0; x < 3; x++)
                {
                    string markInPosition = CurrentGame.GameGrid.Status[x,y];
                    if (markInPosition == null) markInPosition = " ";
                    if (x < 2)
                    {
                        Console.Write(" " + markInPosition + " |");
                    }
                    else
                    {
                        Console.Write(" " + markInPosition);
                    }
                }
                Console.WriteLine();
                if (y < 2)
                {
                    Console.WriteLine("  --- --- ---");
                }
                else
                {
                    Console.WriteLine("   a   b   c");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Player X (" + CurrentGame.PlayerX.Name + ") moves: [" + CurrentGame.PlayerX.MovesString() + "]");
            Console.WriteLine("Player O (" + CurrentGame.PlayerO.Name + ") moves: [" + CurrentGame.PlayerO.MovesString() + "]");
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
