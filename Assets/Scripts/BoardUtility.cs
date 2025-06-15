public static class BoardUtility
{
    public const int file = 8;
    public const int rank = 8;

    public static int GetIndex(int fileIndex, int rankIndex)
    {
        return rankIndex * 8 + fileIndex;
    }
}