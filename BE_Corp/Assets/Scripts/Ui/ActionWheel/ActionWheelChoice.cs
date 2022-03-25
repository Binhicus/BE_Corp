using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using DG.Tweening ;

[System.Serializable]
public enum ActionOveringState
{
    NotOvering,
    Overing
}
public class ActionWheelChoice : MonoBehaviour
{
    public Image MainCircle;
    public Image IconObject;
    public TextMeshProUGUI NameAction ;
    public AnimationCurve AnimCurvRef ;

    [HideInInspector] public ActionOveringState StateMouseOver = ActionOveringState.NotOvering ;

    public void StateOvering(bool State)
    {
        if(State == false) 
        {
            StateMouseOver = ActionOveringState.NotOvering ;

            IconObject.GetComponent<RectTransform>().DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.1f).SetEase(AnimCurvRef);
            MainCircle.GetComponent<Image>().raycastTarget = false ;
            NameAction.gameObject.SetActive(false);
        }

        if(State == true)
        {
            StateMouseOver = ActionOveringState.Overing ;

            IconObject.GetComponent<RectTransform>().DOScale(new Vector3(2f, 2f, 2f), 0.1f).SetEase(AnimCurvRef);
            MainCircle.GetComponent<Image>().raycastTarget = true ;
            NameAction.gameObject.SetActive(true);
        } 
    }


    public void ClickAction()
    {
        Debug.Log(GetComponentInParent<ActionWheel>().TitleCurrentActionChoice.text);
    }

}
