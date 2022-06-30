using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CredtisNameAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform RectTransName ;

    private void OnMouseEnter() 
    {
        RectTransName.DOKill();
        RectTransName.DOAnchorPosY(0f, 0.5f);
    }

    private void OnMouseExit() 
    {
        RectTransName.DOKill();
        RectTransName.DOAnchorPosY(30f, 0.5f);
    }
}
