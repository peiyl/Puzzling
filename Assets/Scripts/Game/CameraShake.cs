using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform ThisTransform = null;
    public float ShakeTime = 2.0f;
    public float ShakeAmount = 3.0f;
    public float ShakeSpeed = 2.0f;
    // Use this for initialization
    void Start()
    {
        ThisTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(Shake());
        }
    }
    public IEnumerator Shake()
    {
        Vector3 OrigPosition = ThisTransform.localPosition;
        float ElapsedTime = 0.0f;
        while (ElapsedTime < ShakeTime)
        {
            Vector3 RandomPoint = OrigPosition + Random.insideUnitSphere * ShakeAmount;
            ThisTransform.localPosition = Vector3.Lerp(ThisTransform.localPosition, RandomPoint, Time.deltaTime * ShakeSpeed);
            yield return null;
            ElapsedTime += Time.deltaTime;
        }
        ThisTransform.localPosition = OrigPosition;
    }
}
