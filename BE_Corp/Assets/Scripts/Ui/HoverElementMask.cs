using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoverElementMask : MonoBehaviour
{
    public float ValueMax ;
    public float Speed ;

    RectTransform ThisRect ;

    private void Awake() 
    {
        ThisRect = GetComponent<RectTransform>();
    }

    public void ShowElement()
    {
        ThisRect.DOKill();
        ThisRect.DOSizeDelta(new Vector2(ValueMax, ThisRect.sizeDelta.y), Speed);
    }

    public void HideElement()
    {
        ThisRect.DOKill();
        ThisRect.DOSizeDelta(new Vector2(0f, ThisRect.sizeDelta.y), (Speed * .7f));
    }
}
