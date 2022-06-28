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
    Questionner,
    Regarder
}
public class ActionWheelChoice : MonoBehaviour
{
    [Header ("Action Wheel Part")]
    public Image MainCircle;
    public Image BackgroundAction;
    public Image ChoiceCirle ;

    public TextMeshProUGUI NameAction ;
    public AnimationCurve AnimCurvRef ;

    [HideInInspector] public ActionOveringState StateMouseOver = ActionOveringState.NotOvering ;
    public Color NormalBackgroundColor ;
    public Color HoverredBackgroundColor ;
    public Color NormalTextColor ;
    public Color HoverredTextColor ;


    [Header ("Action")]
    public IAction TargetAction ;
    [HideInInspector] public ActionPossible StateAction = ActionPossible.Rien ;

    public void StateOvering(bool State)
    {
        if(State == false) 
        {
            StateMouseOver = ActionOveringState.NotOvering ;

            BackgroundAction.GetComponent<RectTransform>().DOScale(new Vector3(.9f, .9f, .9f), 0.1f)/*.SetEase(AnimCurvRef)*/;
            MainCircle.GetComponent<Image>().raycastTarget = false ;

         //  NameAction.gameObject.SetActive(false);
        }

        if(State == true)
        {
            StateMouseOver = ActionOveringState.Overing ;

            BackgroundAction.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0.1f)/*.SetEase(AnimCurvRef)*/;
            MainCircle.GetComponent<Image>().raycastTarget = true ;
          //  NameAction.gameObject.SetActive(true);
        } 
    }

    public void AnimFillAmount(float FillValue, bool Enable)
    {
        if(Enable) ChoiceCirle.fillAmount = 0 ;
        ChoiceCirle.DOFillAmount(FillValue, 0.4f);
    }

    private void Update() 
    {
        if(MainCircle.GetComponent<Image>().raycastTarget && Input.GetMouseButtonDown(0)) ClickAction();

        if(StateMouseOver == ActionOveringState.NotOvering)
        {
            if(BackgroundAction.transform.GetChild(0).GetComponent<Image>().color != NormalBackgroundColor)
            {
                BackgroundAction.transform.GetChild(0).DOKill();
                BackgroundAction.transform.GetChild(0).GetComponent<Image>().DOColor(NormalBackgroundColor, 0.05f);

                BackgroundAction.transform.GetChild(1).DOKill();
                BackgroundAction.transform.GetChild(1).GetComponent<TextMeshProUGUI>().DOColor(NormalTextColor, 0.05f);
            }
        }

        if(StateMouseOver == ActionOveringState.Overing)
        {
            if(BackgroundAction.transform.GetChild(0).GetComponent<Image>().color != HoverredBackgroundColor)
            {
                BackgroundAction.transform.GetChild(0).DOKill();
                BackgroundAction.transform.GetChild(0).GetComponent<Image>().DOColor(HoverredBackgroundColor, 0.15f);

                BackgroundAction.transform.GetChild(1).DOKill();
                BackgroundAction.transform.GetChild(1).GetComponent<TextMeshProUGUI>().DOColor(HoverredTextColor, 0.15f);
            }
        }
    }


    public void ClickAction()
    {
        // State Nothing
        if(StateAction == ActionPossible.Rien)
        {
       //     Debug.Log(GetComponentInParent<ActionWheel>().TitleCurrentActionChoice.text);            
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

        // State Questionner
        if(StateAction == ActionPossible.Regarder)
        {
            TargetAction.OnLook();          
        }

        transform.parent.transform.parent.GetComponent<ActionWheel>().DisableWheel();
    }

}
