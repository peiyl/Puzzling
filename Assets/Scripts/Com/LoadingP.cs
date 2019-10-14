using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LoadingP : MonoBehaviour
{
    public delegate void SceneEvent();
    public SceneEvent SceneOpenEvent;
    public SceneEvent SceneCloseEvent;
    public void CloseGo()
    {
        SceneCloseEvent?.Invoke();
    }
    public void OpenGo()
    {
        SceneOpenEvent?.Invoke();
    }
}
