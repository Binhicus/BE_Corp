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

[System.Serializable]
public enum ActionPossible
{
    Rien,
    Ouvrir,
    Fermer,
    Prendre,
    Utiliser,
    Inspecter,
    Questionner
}
public class ActionWheelChoice : MonoBehaviour
{
    [Header ("Action Wheel Part")]
    public Image MainCircle;
    public Image IconObject;
    public TextMeshProUGUI NameAction ;
    public AnimationCurve AnimCurvRef ;

    [HideInInspector] public ActionOveringState StateMouseOver = ActionOveringState.NotOvering ;

    [Header ("Action")]
    public IAction TargetAction ;
    [HideInInspector] public ActionPossible StateAction = ActionPossible.Rien ;

    public void StateOvering(bool State)
    {
        if(State == false) 
        {
            StateMouseOver = ActionOveringState.NotOvering ;

            IconObject.GetComponent<RectTransform>().DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.1f).SetEase(AnimCurvRef);
            MainCircle.GetComponent<Image>().raycastTarget = false ;
            NameAction.gameObject.SetActive(false);
        }

        if(State == true)
        {
            StateMouseOver = ActionOveringState.Overing ;

            IconObject.GetComponent<RectTransform>().DOScale(new Vector3(1.25f, 1.25f, 1.25f), 0.1f).SetEase(AnimCurvRef);
            MainCircle.GetComponent<Image>().raycastTarget = true ;
            NameAction.gameObject.SetActive(true);
        } 
    }


    public void ClickAction()
    {
        // State Nothing
        if(StateAction == ActionPossible.Rien)
        {
            Debug.Log(GetComponentInParent<ActionWheel>().TitleCurrentActionChoice.text);            
        }

        // State Ouvrir
        if(StateAction == ActionPossible.Ouvrir)
        {
            TargetAction.OnOpen();          
        }

        // State Fermer
        if(StateAction == ActionPossible.Fermer)
        {
            TargetAction.OnClose();          
        }

        // State Prendre
        if(StateAction == ActionPossible.Prendre)
        {
            TargetAction.OnTake();          
        }

        // State Utiliser
        if(StateAction == ActionPossible.Utiliser)
        {
            TargetAction.OnUse();          
        }

        // State Inspecter
        if(StateAction == ActionPossible.Inspecter)
        {
            TargetAction.OnInspect();          
        }

        // State Questionner
        if(StateAction == ActionPossible.Questionner)
        {
            TargetAction.OnQuestion();          
        }

        transform.parent.transform.parent.GetComponent<ActionWheel>().DisableWheel();
    }

}
