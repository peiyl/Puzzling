using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 对需要触发场景调整的按钮单独添加一个脚本
/// </summary>
public class PuzzleSFaceBtnEvent : MonoBehaviour
{
    public GameObject loadingP;
    private void Start()
    {
        loadingP.GetComponent<Animator>().Play("Open");
    }
    private void Update()
    {
        //获取到该物体另一脚本中的字段
        if (transform.GetComponent<PuzzleSFace>().isTouch)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //游戏场景下标为2
                loadingP.GetComponent<LoadingP>().SceneCloseEvent = ()=> { SceneManager.LoadScene("Game"); };
                loadingP.GetComponent<Animator>().Play("Close");
            }
        }
    }
}
