using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Board board;
    BoardGraphics boardGraphics;

    public string fenId;

    private void Start()
    {
        boardGraphics = GetComponent<BoardGraphics>();
        if (boardGraphics == null) boardGraphics = transform.AddComponent<BoardGraphics>();
        
        boardGraphics.UpdateBoard();
        
        board = new Board(fenId);
        
        for (int rank = 0; rank < BoardUtility.rank; rank++)
        for (int file = 0; file < BoardUtility.file; file++)
        {
            int piece = board.squares[BoardUtility.GetIndex(file, rank)];
            Color color = PieceType.IsWhite(piece) ? Color.white : Color.black;
            
            if (Mathf.Abs(piece) == PieceType.Pawn) boardGraphics.CreateText(piece.ToString(), color, file, rank);
            if (Mathf.Abs(piece) == PieceType.Knight) boardGraphics.CreateText(piece.ToString(), color, file, rank);
            if (Mathf.Abs(piece) == PieceType.Bishop) boardGraphics.CreateText(piece.ToString(), color, file, rank);
            if (Mathf.Abs(piece) == PieceType.Rook) boardGraphics.CreateText(piece.ToString(), color, file, rank);
            if (Mathf.Abs(piece) == PieceType.Queen) boardGraphics.CreateText(piece.ToString(), color, file, rank);
            if (Mathf.Abs(piece) == PieceType.King) boardGraphics.CreateText(piece.ToString(), color, file, rank);
            Debug.Log("Piece Type : " + piece);
        }
    }
}