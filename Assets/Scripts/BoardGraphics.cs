using NaughtyAttributes;
using UnityEngine;

public class BoardGraphics : MonoBehaviour
{
    [HideInInspector] public Transform squareParent; 
    public Sprite squareSprite;
    public float squareSize;
    public Vector3 boardPosition;
    public bool isCenter;

    public Color whiteColor;
    public Color blackColor;
    
    [Button]
    public void UpdateBoard()
    {
        if (squareParent == null) Initialize();
        UpdateBoard(boardPosition, squareSize, isCenter);
    }
    
    void Initialize()
    {
        if (transform.childCount > 0) squareParent = transform.GetChild(0).transform;
        if (transform.childCount <= 0) squareParent = transform;
    }
    
    void CreateSquare(Vector3 position, float size, Color color)
    {
        SpriteRenderer square = new GameObject(position.ToString()).AddComponent<SpriteRenderer>();
        square.transform.parent = squareParent;
        square.transform.localPosition = position;
        square.transform.localScale = new Vector3(size, size, 1);
        square.color = color;
        square.sprite = squareSprite;
    }

    void CreateBoard(Vector2 offsetPosition, float size, bool center = true)
    {
        offsetPosition = center ? CalculateCenterOffset(size) : offsetPosition;
        
        for (int rank = 0; rank < BoardUtility.rank; rank++)
        for (int file = 0; file < BoardUtility.file; file++)
        {
            Vector2 position = new Vector2(file, rank) * size - offsetPosition;
            Color color = (rank + file) % 2 == 0 ? blackColor : whiteColor;
            CreateSquare(position, size, color);
        }
    }

    void ClearBoard()
    {
        for (int i = squareParent.childCount - 1; i >= 0; i--)
            DestroyImmediate(squareParent.GetChild(i).gameObject);
    }

    Vector2 CalculateCenterOffset(float size)
    {
        int rank = BoardUtility.rank;
        int file = BoardUtility.file;
        Vector2 centerOffsetPosition = new Vector2(file, rank) * size / 2f - Vector2.one * 0.5f * size;
        return centerOffsetPosition;
    }

    void UpdateBoard(Vector2 offsetPosition, float size, bool center = true)
    {
        if (squareParent.childCount > 0) ClearBoard();
        if (squareParent.childCount == 0) CreateBoard(offsetPosition, size, center);
    }
}
