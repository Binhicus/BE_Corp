using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationLoading : MonoBehaviour
{
    public RectTransform LoadImage ;

    private void OnEnable() 
    {
        LoadImage.localEulerAngles = new Vector3(0f, 0f, 0f) ;
        StartCoroutine(TurnAnimation());
    }

    private void OnDisable() 
    {
        StopAllCoroutines();
    }

    IEnumerator TurnAnimation()
    {
        yield return new WaitForSeconds(0.15f);
        LoadImage.Rotate(new Vector3(0f, 0f, -36f)) ;
        StartCoroutine(TurnAnimation());
    }
}
