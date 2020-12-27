using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe.Entities
{
    class Grid
    {
        public string[,] Status { get; private set; }

        public Grid()
        {
            Status = new string[3,3];
        }

        public void PlaceInGrid(string mark, Position position)
        {
            if (Status[position.X, position.Y] == null)
            {
                Status[position.X, position.Y] = mark;
            }
            else
            {
                throw new ApplicationException("The position selected is not empty!");
            }
        }
    }
}
