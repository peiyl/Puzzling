using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Puzzle myPuzzle;
    public SpriteRenderer spriteRenderer;

    public void SetPlayerPuzzleState(Puzzle puzzle,string dirStr)
    {
        myPuzzle = puzzle;
        spriteRenderer.sprite = Resources.Load<Sprite>("Textures/Player"+dirStr);
    }
    
}
