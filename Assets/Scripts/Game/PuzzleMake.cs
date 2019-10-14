using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMake : MonoBehaviour
{
    public Puzzle puzzle;
    private float[] colorArr = new float[3];
    public void UpdatePuzzle()
    {
        for (int i = 0; i < colorArr.Length; i++)
        {
            colorArr[i] = Random.Range(0f, 1f);
        }
        GetComponent<SpriteRenderer>().color = new Color(colorArr[0], colorArr[1], colorArr[2]);
        GetComponent<Animator>().SetTrigger("go");
    }
    private void PuzzleTrig()
    {
        GameManager.Instance.PuzzleTrig(gameObject);
    }
}
