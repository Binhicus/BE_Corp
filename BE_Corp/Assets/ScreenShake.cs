﻿using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    public GameObject[] Panel;

    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
            
        }
    }

    public IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Debug.Log("je shake" + gameObject.name);
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        
        transform.position = startPosition;
    }
}