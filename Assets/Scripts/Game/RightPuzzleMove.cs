using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPuzzleMove : PuzzleMake
{
    private void Start()
    {
        puzzle = GameManager.Instance.rightPuzzle;
    }
}
