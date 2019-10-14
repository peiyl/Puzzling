using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye02 : MonoBehaviour
{
    public void TheLastEvent()
    {
        GameManager.Instance.SetPlayerFaceShow(true, false, false);
    }
}
