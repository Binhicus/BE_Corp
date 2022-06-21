using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening ;

public class AnimationIndication : MonoBehaviour
{
    private RectTransform ThisRectT ;

    void Awake()
    {
        ThisRectT = GetComponent<RectTransform>() ;
    }


    public void ShowIndication()
    {
        StopAllCoroutines();
        StartCoroutine(IShowIndication());
    }

    IEnumerator IShowIndication()
    {
        ThisRectT.DOAnchorPosY(0f, 0.15f);
        yield return new WaitForSeconds(0.03f);
        ThisRectT.DOAnchorPosY(6f, 0.05f);
    }

    public void HideIndication()
    {
        StopAllCoroutines();
        StartCoroutine(IHideIndication());
    }

    IEnumerator IHideIndication()
    {
        ThisRectT.DOAnchorPosY(0f, 0.05f);
        yield return new WaitForSeconds(0.01f);
        ThisRectT.DOAnchorPosY(75f, 0.15f);
    }
}
