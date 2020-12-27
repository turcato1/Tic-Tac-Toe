namespace Tic_Tac_Toe.Entities
{
    class Game
    {
        public bool HasFinished { get; private set; }
        public Player Winner { get; private set; }
        public Grid GameGrid { get; private set; }
        public Player PlayerX { get; private set; }
        public Player PlayerO { get; private set; }
        public string CurrentTurnMark { get; private set; }
        public int TurnNumber { get; private set; }

        public Game(Player playerX, Player playerO)
        {
            HasFinished = false;
            Winner = null;
            GameGrid = new Grid();
            PlayerX = playerX;
            PlayerO = playerO;
            CurrentTurnMark = "X";
            TurnNumber = 1;
        }

        public void NewMove(string mark, Position move)
        {
            GameGrid.PlaceInGrid(mark, move);
            CheckWinner();
            TurnNumber++;
            if (!HasFinished)
            {
                if (CurrentTurnMark == "X")
                {
                    CurrentTurnMark = "O";
                }
                else
                {
                    CurrentTurnMark = "X";
                }
            }
        }
        private void CheckWinner()
        {      //Horizontal
            if ((GameGrid.Status[0, 0] == GameGrid.Status[1, 0] && GameGrid.Status[1, 0] == GameGrid.Status[2, 0] && GameGrid.Status[2, 0] != null)
                || (GameGrid.Status[0, 1] == GameGrid.Status[1, 1] && GameGrid.Status[1, 1] == GameGrid.Status[2, 1] && GameGrid.Status[2, 1] != null)
                || (GameGrid.Status[0, 2] == GameGrid.Status[1, 2] && GameGrid.Status[1, 2] == GameGrid.Status[2, 2] && GameGrid.Status[2, 2] != null)
                //Vertical
                || (GameGrid.Status[0, 0] == GameGrid.Status[0, 1] && GameGrid.Status[0, 1] == GameGrid.Status[0, 2] && GameGrid.Status[0, 2] != null)
                || (GameGrid.Status[1, 0] == GameGrid.Status[1, 1] && GameGrid.Status[1, 1] == GameGrid.Status[1, 2] && GameGrid.Status[1, 2] != null)
                || (GameGrid.Status[2, 0] == GameGrid.Status[2, 1] && GameGrid.Status[2, 1] == GameGrid.Status[2, 2] && GameGrid.Status[2, 2] != null)
                //Diagonal descendent
                || (GameGrid.Status[0, 0] == GameGrid.Status[1, 1] && GameGrid.Status[1, 1] == GameGrid.Status[2, 2] && GameGrid.Status[2, 2] != null)
                //Diagonal ascendent
                || (GameGrid.Status[0, 2] == GameGrid.Status[1, 1] && GameGrid.Status[1, 1] == GameGrid.Status[2, 0] && GameGrid.Status[2, 0] != null))
            {
                HasFinished = true;
                if (CurrentTurnMark == "X")
                {
                    Winner = PlayerX;
                }
                else
                {
                    Winner = PlayerO;
                }
            }
            else if (TurnNumber >= 9)
            {
                HasFinished = true;
            }
        }
    }
}
