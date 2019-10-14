using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextS;
    public Button againBtn;
    public Button backStartBtn;
    public GameObject loadingP;
    void Start()
    {
        scoreText.text = GameManager.Instance.score.ToString();
        scoreTextS.text = GameManager.Instance.score.ToString();
        loadingP.GetComponent<Animator>().Play("Open");
        againBtn.onClick.AddListener(() =>
        {
            loadingP.GetComponent<LoadingP>().SceneCloseEvent = () => { SceneManager.LoadScene("Game"); };
            loadingP.GetComponent<Animator>().Play("Close");
        });
        backStartBtn.onClick.AddListener(() => 
        {
            loadingP.GetComponent<LoadingP>().SceneCloseEvent = () => { SceneManager.LoadScene("Start"); };
            loadingP.GetComponent<Animator>().Play("Close");
        });
    }

}
