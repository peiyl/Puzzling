using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void GameOverEvent()
    {
        GameManager.Instance.loadingPanel.GetComponent<Animator>().Play("Close");
    }
}
