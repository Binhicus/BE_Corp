using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoverElementMask : MonoBehaviour
{
    public float HeightMax ;
    RectTransform ThisRect ;

    private void Awake() 
    {
        ThisRect = GetComponent<RectTransform>();
    }

    public void ShowElement()
    {
        ThisRect.DOKill();
        ThisRect.DOSizeDelta(new Vector2(HeightMax, ThisRect.sizeDelta.y), 0.15f);
    }

    public void HideElement()
    {
        ThisRect.DOKill();
        ThisRect.DOSizeDelta(new Vector2(0f, ThisRect.sizeDelta.y), 0.1f);
    }
}
