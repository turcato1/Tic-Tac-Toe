using System;
using Tic_Tac_Toe.Entities;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game starting message
            Console.WriteLine("----- TIC TAC TOE -----");
            Console.WriteLine();

            //Collect players names
            Console.Write("Player 'X' Name: ");
            string name = Console.ReadLine();
            Player playerX = new Player(name);

            Console.Write("Player 'O' Name: ");
            name = Console.ReadLine();
            Player playerO = new Player(name);

            //Starts a new game and creates its interface for interaction with players
            Game game = new Game(playerX, playerO);
            GameInterface gameinterface = new GameInterface(game);

            while (!game.HasFinished)
            {
                try
                {
                    gameinterface.UpdateScreen();
                    game.NewMove(game.CurrentTurnMark, gameinterface.GetPlayerMove());
                }
                catch (ApplicationException e)
                {
                    Console.WriteLine("Game violation: "+ e.Message);
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected error: " + e.Message);
                    Console.ReadLine();
                }
            }
            gameinterface.UpdateScreen();
            Console.WriteLine();
            Console.WriteLine("G A M E  O V E R !!");
            if (game.Winner == null)
            {
                Console.WriteLine("Draw! There was no winner!!! Try again!");
            }
            else
            {
                Console.WriteLine("We have a winner: " + game.Winner.Name + " playing with mark " + game.CurrentTurnMark);
            }

        }
    }
}
