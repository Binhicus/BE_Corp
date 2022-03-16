using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

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

    [HideInInspector] public ActionOveringState StateMouseOver = ActionOveringState.NotOvering ;

    void Update()
    {
     /*   if(StateMouseOver != ActionOveringState.NotOvering)
        {
            StateOvering();
        }*/
    }

    public void StateOvering(bool State)
    {
        if(State == false) 
        {
            StateMouseOver = ActionOveringState.NotOvering ;

            IconObject.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            MainCircle.GetComponent<Image>().raycastTarget = false ;
        }

        if(State == true)
        {
            StateMouseOver = ActionOveringState.Overing ;

            IconObject.GetComponent<RectTransform>().localScale = new Vector3(2f, 2f, 2f);
            MainCircle.GetComponent<Image>().raycastTarget = true ;
        } 
    }


    public void ClickAction()
    {
        Debug.Log(GetComponentInParent<ActionWheel>().TitleCurrentActionChoice.text);
    }

}
