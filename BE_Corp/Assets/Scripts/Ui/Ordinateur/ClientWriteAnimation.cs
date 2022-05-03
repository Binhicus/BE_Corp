using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClientWriteAnimation : MonoBehaviour
{
    public RectTransform LoadImg1 ;
    public RectTransform LoadImg2 ;
    public RectTransform LoadImg3 ;


    void Start()
    {
        StartCoroutine(StartDifferentLoad());
    }

    IEnumerator StartDifferentLoad()
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(LoadImageAnimation(LoadImg1));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(LoadImageAnimation(LoadImg2));
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(LoadImageAnimation(LoadImg3));

    }

    IEnumerator LoadImageAnimation(RectTransform LoadImgRect)
    {
        LoadImgRect.DOJumpAnchorPos(new Vector2(0, LoadImgRect.anchoredPosition.y), 10f, 1, 0.25f);
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(LoadImageAnimation(LoadImgRect));
    }
}
