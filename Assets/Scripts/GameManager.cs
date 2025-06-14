using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    BoardGraphics boardGraphics;

    private void Start()
    {
        boardGraphics = GetComponent<BoardGraphics>();
        if (boardGraphics == null) boardGraphics = transform.AddComponent<BoardGraphics>();
        
        boardGraphics.UpdateBoard();
    }
}