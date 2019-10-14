using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle
{
    public abstract bool PuzzleIsTure(Puzzle puzzle);
}
public class IdlePuzzle : Puzzle
{
    public override bool PuzzleIsTure(Puzzle puzzle)
    {
        return false;
    }
}
public class LeftPuzzle : Puzzle
{
    public override bool PuzzleIsTure(Puzzle puzzle)
    {
        return puzzle == GameManager.Instance.rightPuzzle;
    }
}
public class RightPuzzle : Puzzle
{
    public override bool PuzzleIsTure(Puzzle puzzle)
    {
        return puzzle == GameManager.Instance.leftPuzzle;
    }
}
