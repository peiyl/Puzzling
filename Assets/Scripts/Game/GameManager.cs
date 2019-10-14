using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Puzzle idlePuzzle = new IdlePuzzle();
    public Puzzle leftPuzzle = new LeftPuzzle();
    public Puzzle rightPuzzle = new RightPuzzle();
    public int score = 0;
    public int targetScore = 100;
    public float spaceTime = 2.0f;

    public Player player;

    public GameObject eye01;
    public GameObject eye02;
    public GameObject eye03;
    public ParticleSystem winEffect;
    public ParticleSystem dieEffect;

    public Transform shakeCameraTransform;
    public float shakeTime = 0.2f;
    public float shakeAmount = 3.0f;
    public float shakeSpeed = 2.0f;
    /// <summary>
    /// 孵化点
    /// </summary>
    public Transform incPos;
    public GameObject leftPuzzlePreFab;
    public GameObject rightPuzzlePreFab;
    public TextMeshProUGUI scoreShadowText;
    public TextMeshProUGUI scoreText;
    public Animator scoreAnimator;

    public Animator gameOver;
    public GameObject loadingPanel;

    private int rangNum;
    private List<GameObject> leftPuzzleList;
    private List<GameObject> rightPuzzleList;
    private List<GameObject> puzzleList;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        score = 0;
        UpdateScoreText();
        SetPlayerFaceShow(true, false, false);
        leftPuzzleList = new List<GameObject>();
        rightPuzzleList = new List<GameObject>();
        puzzleList = new List<GameObject>();
        loadingPanel.GetComponent<LoadingP>().SceneOpenEvent = () => { StartCoroutine( CreatePuzzle()); };
        loadingPanel.GetComponent<LoadingP>().SceneCloseEvent = () => { SceneManager.LoadScene("GameOver"); };
        loadingPanel.GetComponent<Animator>().Play("Open");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.SetPlayerPuzzleState(leftPuzzle, "Left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.SetPlayerPuzzleState(rightPuzzle, "Right");
        }
        else
        {
            player.SetPlayerPuzzleState(idlePuzzle, "Idle");
        }
    }
    private void SpacePuzzle(List<GameObject> puzzleList)
    {
        foreach (GameObject item in puzzleList)
        {
            item.GetComponent<Animator>().enabled = false;
        }
    }
    private void CreateNewPuzzle()
    {
        rangNum = Random.Range(0, 2);
        GameObject go;
        if (rangNum == 0)
        {
            if (leftPuzzleList.Count == 0)
            {
                go = Instantiate(leftPuzzlePreFab, incPos.position, Quaternion.identity, incPos);
                puzzleList.Add(go);
            }
            else
            {
                go = leftPuzzleList[leftPuzzleList.Count - 1];
                leftPuzzleList.RemoveAt(leftPuzzleList.Count - 1);
            }
        }
        else
        {
            if (rightPuzzleList.Count != 0)
            {
                go = rightPuzzleList[rightPuzzleList.Count - 1];
                rightPuzzleList.RemoveAt(rightPuzzleList.Count - 1);
            }
            else
            {
                go = Instantiate(rightPuzzlePreFab, incPos.position, Quaternion.identity, incPos);
                puzzleList.Add(go);
            }

        }
        go.GetComponent<PuzzleMake>().UpdatePuzzle();
    }
    public void AddScore(int num = 1)
    {
        score += num;
    }
    public void UpdateScoreText()
    {
        scoreShadowText.text = score + "/" + targetScore;
        scoreText.text = score + "/" + targetScore;
    }
    public void PuzzleTrig(GameObject gameObject)
    {
        Puzzle thePuzzle = gameObject.GetComponent<PuzzleMake>().puzzle;
        //回收go
        if (thePuzzle == leftPuzzle)
        {
            leftPuzzleList.Add(gameObject);
        }
        else if (thePuzzle == rightPuzzle)
        {
            rightPuzzleList.Add(gameObject);
        }
        //判断对错
        if (player.myPuzzle.PuzzleIsTure(thePuzzle))
        {
            AddScore();
            UpdateScoreText();
            winEffect.Play();
            SetPlayerFaceShow(false, true, false);
            scoreAnimator.SetTrigger("getscore");
        }
        else
        {
            StopAllCoroutines();
            SpacePuzzle(puzzleList);
            dieEffect.Play();
            SetPlayerFaceShow(false, false, true);
            gameOver.Play("GameOver");
        }
        StartCoroutine(CameraShake());
    }
    public void SetPlayerFaceShow(bool eye1, bool eye2, bool eye3)
    {
        eye01.SetActive(eye1);
        eye02.SetActive(eye2);
        eye03.SetActive(eye3);
    }
    IEnumerator CreatePuzzle()
    {
        yield return new WaitForSeconds(spaceTime);
        CreateNewPuzzle();
        StartCoroutine(CreatePuzzle());
    }
    public IEnumerator CameraShake()
    {
        Vector3 OrigPosition = shakeCameraTransform.localPosition;
        float ElapsedTime = 0.0f;
        while (ElapsedTime < shakeTime)
        {
            Vector3 RandomPoint = OrigPosition + Random.insideUnitSphere * shakeAmount;
            shakeCameraTransform.localPosition = Vector3.Lerp(shakeCameraTransform.localPosition, RandomPoint, Time.deltaTime * shakeSpeed);
            yield return null;
            ElapsedTime += Time.deltaTime;
        }
        shakeCameraTransform.localPosition = OrigPosition;
    }
}
