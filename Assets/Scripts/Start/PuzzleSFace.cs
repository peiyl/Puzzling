using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSFace :MonoBehaviour
{
    public Animator myBubbleAnimator;
    public bool isTouch = false;
    private void Update()
    {
        BubbleMove();
    }
    private void OnMouseEnter()
    {
        isTouch = true;
    }

    private void OnMouseExit()
    {
        isTouch = false;
    }
    private void BubbleMove()
    {
        if (isTouch)
        {
            myBubbleAnimator.SetBool("touch", true);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/PuzzleSB2");
        }
        else
        {
            myBubbleAnimator.SetBool("touch", false);
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/PuzzleSB1");
        }
    }
}
