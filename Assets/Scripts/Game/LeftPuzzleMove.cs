using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPuzzleMove : PuzzleMake
{
    private void Start()
    {
        puzzle = GameManager.Instance.leftPuzzle;
    }
  
}
