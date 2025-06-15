using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class BoardGraphics : MonoBehaviour
{
    private Dictionary<Vector2, Transform> squares = new Dictionary<Vector2, Transform>(); 
    [HideInInspector] public Transform squareParent; 
    public Sprite squareSprite;
    [Range(0.1f, 3f)] public float squareSize;
    public Vector3 boardPosition;
    public bool isCenter;

    public Color whiteColor;
    public Color blackColor;
    public Color textColor;
    
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
    
    Transform CreateSquare(Vector3 position, float size, Color color)
    {
        SpriteRenderer square = new GameObject(position.ToString()).AddComponent<SpriteRenderer>();
        square.transform.parent = squareParent;
        square.transform.localPosition = position;
        square.transform.localScale = new Vector3(size, size, 1);
        square.color = color;
        square.sprite = squareSprite;
        return square.transform;
    }

    void CreateBoard(Vector2 offsetPosition, float size, bool center = true)
    {
        offsetPosition = center ? CalculateCenterOffset(size) : offsetPosition;

        int index = 0;
        for (int rank = 0; rank < BoardUtility.rank; rank++)
        for (int file = 0; file < BoardUtility.file; file++)
        {
            Vector2 position = new Vector2(file, rank) * size - offsetPosition;
            Color color = (rank + file) % 2 == 0 ? blackColor : whiteColor;
            Transform squareTransform = CreateSquare(position, size, color);
            squares.Add(new Vector2(file, rank), squareTransform);
            CreateText(index.ToString(), textColor , file, rank);
            index++;
        }
    }

    void ClearBoard()
    {
        for (int i = squareParent.childCount - 1; i >= 0; i--)
            DestroyImmediate(squareParent.GetChild(i).gameObject);
        
        squares.Clear();
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

    void CreateText(string text, Color color, int file, int rank)
    {
        Vector2 cord = new Vector2(file, rank);
        if (squares.ContainsKey(cord))
        {
            if (squares[cord].childCount <= 0)
            {
                var textObject = new GameObject("Text");
                textObject.transform.parent = squares[cord];
                TextMeshPro textMesh = textObject.AddComponent<TextMeshPro>();
                textMesh.text = text;
                textMesh.color = color;
                textMesh.fontSize = 6f;
                textMesh.alignment = TextAlignmentOptions.Center;
                textMesh.rectTransform.sizeDelta = Vector2.one * squareSize;
                textObject.transform.localPosition = Vector3.zero;
            }
            else if (squares[cord].childCount > 0)
            {
                var textObject = squares[cord].GetChild(0).gameObject;
                TextMeshPro textMesh = textObject.GetComponent<TextMeshPro>();
                textMesh.text = text;
                textMesh.color = color;
                textMesh.fontSize = 6f;
                textMesh.alignment = TextAlignmentOptions.Center;
                textMesh.rectTransform.sizeDelta = Vector2.one * squareSize;
                textObject.transform.localPosition = Vector3.zero;
            }
        }
    }

    void DestroyText(int file, int rank)
    {
        Vector2 cord = new Vector2(file, rank);
        if (squares.ContainsKey(cord))
        {
            if (squares[cord].childCount > 0) DestroyImmediate(squares[cord].GetChild(0).gameObject);;
        }
    }

    [Button]
    void DestroyAllTexts()
    {
        for (int rank = 0; rank < BoardUtility.rank; rank++)
        for (int file = 0; file < BoardUtility.file; file++)
        {
            DestroyText(file, rank);
        }
    }
}
