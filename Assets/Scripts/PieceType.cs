public static class PieceType
{
    public const int None = 0;
    public const int Pawn = 1;
    public const int Knight = 2;
    public const int Bishop = 3;
    public const int Rook = 4;
    public const int Queen = 5;
    public const int King = 6;

    public const int white = 1;
    public const int black = -1;

    public static bool IsWhite(int piece)
    {
        return piece > 0;
    }
}