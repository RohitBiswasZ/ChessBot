using System.Collections.Generic;

public static class FENUtility
{
    public static int[] GenerateFEN(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR")
    {
        int[] square = new int[64];

        Dictionary<char, int> pieceMap = new Dictionary<char, int>
        {
            {'p', PieceType.Pawn * -1}, {'P', PieceType.Pawn * 1},
            {'n', PieceType.Knight * -1}, {'N', PieceType.Knight * 1},
            {'b', PieceType.Bishop * -1}, {'B', PieceType.Bishop * 1},
            {'r', PieceType.Rook * -1}, {'R', PieceType.Rook * 1},
            {'q', PieceType.Queen * -1}, {'Q', PieceType.Queen * 1},
            {'k', PieceType.King * -1}, {'K', PieceType.King * 1},
        };
        
        int file = 0;
        int rank = 7;
        char[] fenArray = fen.ToCharArray();
        foreach (var fenChar in fenArray)
        {
            if (fenChar == ' ') break;
            
            if (fenChar == '/')
            {
                rank--;
                file = 0;
            }
            
            if (char.IsDigit(fenChar))
            {
                file += int.Parse(fenChar.ToString());
            }
            
            if (char.IsDigit(fenChar) == false && fenChar != '/')
            {
                square[BoardUtility.GetIndex(file, rank)] = pieceMap[fenChar];
                file++;
            }
            
            // if (fenChar == 'p' || fenChar == 'P') {
            //     square[BoardUtility.GetIndex(file, rank)] = PieceType.Pawn * team;
            //     file++;
            // }
            //
            // if (fenChar == 'r' || fenChar == 'R') {
            //     square[BoardUtility.GetIndex(file, rank)] = PieceType.Rook * team;
            //     file++;
            // }
            //
            // if (fenChar == 'n' || fenChar == 'N') {
            //     square[BoardUtility.GetIndex(file, rank)] = PieceType.Knight * team;
            //     file++;
            // }
            //
            // if (fenChar == 'b' || fenChar == 'B') {
            //     square[BoardUtility.GetIndex(file, rank)] = PieceType.Bishop * team;
            //     file++;
            // }
            //
            // if (fenChar == 'q' || fenChar == 'Q') {
            //     square[BoardUtility.GetIndex(file, rank)] = PieceType.Queen * team;
            //     file++;
            // }
            //
            // if (fenChar == 'k' || fenChar == 'K') {
            //     square[BoardUtility.GetIndex(file, rank)] = PieceType.King * team;
            //     file++;
            // }
        }
        
        return square;
    }
}