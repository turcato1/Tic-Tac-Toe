using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.Entities
{
    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(char charpositionX, int positionY)
        {
            int tempXPosition = charpositionX - 'a';
            if (tempXPosition >= 0 && tempXPosition <= 2 && positionY >= 1 && positionY <= 3)
            {
                X = tempXPosition;
                Y = 3 - positionY;
            }
            else
            {
                throw new ApplicationException("The position informed is not valid!");
            }
        }

        public string ToStringGrid()
        {
            return (3 - Y).ToString() + (char.ConvertFromUtf32(X + 'a')).ToString();
        }
    }
}