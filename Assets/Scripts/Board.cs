public class Board
{
    public int[] squares;
    
    public Board(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR")
    {
        squares = new int[64];
        squares = FENUtility.GenerateFEN(fen);
    }
}