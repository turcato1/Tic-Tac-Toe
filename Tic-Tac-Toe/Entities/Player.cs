using System.Collections.Generic;

namespace Tic_Tac_Toe.Entities
{
    class Player
    {
        public string Name { get; private set; }
        public List<Position> Moves { get; private set; }

        public Player(string name)
        {
            //Player's name
            Name = name;
            //Initializes a new moves list
            Moves = new List<Position>();
        }

        //Adds one new played position to player's object list
        public void AddMove(Position position)
        {
            Moves.Add(position);
        }

        //Returns a string containing all players position
        public string MovesString()
        {
            string smoves = "";
            foreach (Position p in Moves)
            {
                smoves += p.ToStringGrid() + " ";
            }
            return smoves;
        }
    }
}
